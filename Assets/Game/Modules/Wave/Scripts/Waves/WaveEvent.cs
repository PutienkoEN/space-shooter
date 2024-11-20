// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveEvent.cs
// ------------------------------------------------------------------------------

using System;
using Game.Modules.Wave.Config;

namespace Game.Modules.Wave.Waves
{
    public sealed class WaveEvent : IWave
    {
        public event Action OnWaveFinished;
        
        public IWave Init(IWaveData data)
        {
            return this;
        }

        public void StartWave()
        {
            
        }

        public void Dispose()
        {
            
        }
    }
}