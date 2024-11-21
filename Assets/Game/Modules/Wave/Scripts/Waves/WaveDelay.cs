// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveDelay.cs
// ------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Game.Modules.Wave.Config;
using UnityEngine;

namespace Game.Modules.Wave.Waves
{
    public sealed class WaveDelay : IWave
    {
        public event Action OnWaveFinished;
        
        private float _duration;
        private float _remainingTime;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _isDelayStarted;

        public IWave Init(WaveDelayData data)
        {
            Debug.Log("[WaveDelay] Init");
            _duration = data.Duration;

            return this;
        }

        public void StartWave()
        {
            if (_isDelayStarted)
            {
                throw new InvalidOperationException($"Delay has already been started. Duration = {_duration} RemainingTime = {TimeSpan.FromSeconds(_remainingTime):mm\\:ss} isDelayStarted = {_isDelayStarted}");
            }
            Debug.Log("[WaveDelay] StartWave");
            StartDelayAsync().Forget();
        }

        private async UniTaskVoid StartDelayAsync()
        {
            if (_isDelayStarted)
            {
                Debug.LogWarning("Delay has already been started.");
                return;
            }

            _isDelayStarted = true;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                _remainingTime = _duration;
                while (_remainingTime > 0)
                {
                    Debug.Log(TimeSpan.FromSeconds(_remainingTime).ToString(@"mm\:ss"));
                    await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: _cancellationTokenSource.Token);
                    _remainingTime -= 1f;
                }

                OnWaveFinished?.Invoke();
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning("Wave delay was canceled.");
            }
            finally
            {
                _isDelayStarted = false;
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}