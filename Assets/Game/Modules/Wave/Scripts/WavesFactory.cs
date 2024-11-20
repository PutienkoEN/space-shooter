// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WavesFactory.cs
// ------------------------------------------------------------------------------

using System;
using Game.Modules.Wave.Config;
using Game.Modules.Wave.Waves;
using Zenject;

namespace Game.Modules.Wave
{
    public sealed class WavesFactory
    {
        private readonly DiContainer _container;
        
        public WavesFactory(DiContainer container)
        {
            _container = container;
        }

        public IWave Create(IWaveData waveData)
        {
            return waveData switch
            {
                WaveEnemyGroupData enemyGroupData => _container.Resolve<WaveEnemyGroup>().Init(enemyGroupData),
                WaveDelayData delayData => _container.Resolve<WaveDelay>().Init(delayData),
                WaveEventData eventData => _container.Resolve<WaveEvent>().Init(eventData),
                _ => throw new ArgumentException($"Unknown wave data type: {waveData.GetType()}")
            };
        }
    }
}