// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveDelay.cs
// ------------------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;
using Game.Modules.Wave.Config;
using UnityEngine;

namespace Game.Modules.Wave.Waves
{
    public interface IWaveDelay
    {
        event Action<float> OnTimeUpdated;
    }
    
    public sealed class WaveDelay : IWave, IWaveDelay
    {
        public event Action OnWaveFinished;
        public event Action<float> OnTimeUpdated;
        
        private float _duration;
        private CancellationTokenSource _cancellationTokenSource;
        private bool _delayStarted;

        public IWave Init(IWaveData data)
        {
            if (data is not WaveDelayData delayData)
            {
                throw new InvalidOperationException($"[WaveDelay] Unknown wave data type: {data.GetType()}");
            }

            Debug.Log("[WaveDelay] Init");
            _duration = delayData.Duration;

            return this;
        }

        public void StartWave()
        {
            if (_delayStarted)
            {
                throw new InvalidOperationException("Delay has already been started.");
            }
            Debug.Log("[WaveDelay] StartWave");
            StartDelayAsync().ConfigureAwait(false);
        }

        private async Task StartDelayAsync()
        {
            if (_delayStarted)
            {
                Debug.LogWarning("Delay has already been started.");
                return;
            }

            _delayStarted = true;
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                var remainingTime = _duration;
                while (remainingTime > 0)
                {
                    Debug.Log(TimeSpan.FromSeconds(remainingTime).ToString(@"mm\:ss"));
                    OnTimeUpdated?.Invoke(remainingTime);
                    await Task.Delay(1000, _cancellationTokenSource.Token);
                    remainingTime -= 1f;
                }

                OnWaveFinished?.Invoke();
            }
            catch (OperationCanceledException)
            {
                Debug.LogWarning("Wave delay was canceled.");
            }
            finally
            {
                _delayStarted = false;
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource?.Cancel();
            _cancellationTokenSource?.Dispose();
        }
    }
}