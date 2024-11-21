// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveConfig.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Wave.Config
{
    public abstract class WaveConfig : ScriptableObject
    {
        public abstract IWaveData GetWaveData();
    }
    public interface IWaveData { }
}