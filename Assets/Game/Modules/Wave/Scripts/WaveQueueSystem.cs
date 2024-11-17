// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveQueueSystem.cs
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Game.Modules.Wave.Interface;
using ModestTree;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.Wave
{
    public interface IWaveQueueSystem
    {
        int CountWaves { get; }
        bool IsPlaying { get; }
        event Action OnWaveQueueFinished;
    }
    
    internal sealed class WaveQueueSystem : IWaveQueueSystem, IGameStartListener, IGamePauseListener, IGameResumeListener, IDisposable
    {
        public event Action OnWaveQueueFinished;
        public int CountWaves => _waves.Count;
        public bool IsPlaying => _isPlaying;

        private readonly Queue<IWave> _waves = new();
        private IWave _currentWave;
        private bool _isPlaying;
        
        //TODO Maybe move it to the Init() method.
        public WaveQueueSystem(IListWaveConfig listWaveConfig)
        {
            if (listWaveConfig == null) throw new ArgumentNullException(nameof(listWaveConfig));

            foreach (var waveData in listWaveConfig.GetListWaveConfig())
            {
                _waves.Enqueue(waveData.GetWave());
            }
        }

        public void OnGameStart()
        {
            _isPlaying = true;
            StartNextWave();
        }

        public void OnGamePause()
        {
            _isPlaying = false;
        }

        public void OnGameResume()
        {
            _isPlaying = true;
            StartNextWave();
        }

        private void StartNextWave()
        {
            if (CanNotStartNextWave(out var message))
            {
                Debug.LogWarning(message);
                return;
            }

            _currentWave = _waves.Dequeue();
            _currentWave.OnWaveFinished += OnWaveFinished;
            _currentWave.StartWave();
        }

        private bool CanNotStartNextWave(out string message)
        {
            message = string.Empty;
            
            if (!_isPlaying)
            {
                message = "Is not Playing Wave";
                return true;
            }

            if (_currentWave != null)
            {
                message = "Cannot start next wave until current one is finished.";
                return true;
            }

            if (_waves.IsEmpty())
            {
                message = "All waves completed!";
                OnWaveQueueFinished?.Invoke();
                return true;
            }

            return false;
        }

        private void OnWaveFinished()
        {
            DisposeCurrentWave();
            StartNextWave();
        }

        private void DisposeCurrentWave()
        {
            if (_currentWave == null)
            {
                Debug.LogError("Trying to clear an empty wave.");
                return;
            }
            
            Debug.Log($"Current {_currentWave.GetType().Name} wave has been stopped.");
            _currentWave.Dispose();
            _currentWave.OnWaveFinished -= OnWaveFinished;
            _currentWave = null;
        }
        
        private void ResetQueue()
        {
            foreach (var wave in _waves)
            {
                wave.Dispose();
            }

            _waves.Clear();
            Debug.Log("Wave queue has been reset.");
        }

        public void Dispose()
        {
            DisposeCurrentWave();
            ResetQueue();
        }
    }
}