// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveConfig.cs
// ------------------------------------------------------------------------------

using Game.Modules.Wave.Interface;
using UnityEngine;

namespace Game.Modules.Wave.Data
{
    public abstract class WaveConfig : ScriptableObject
    {
        public abstract IWaveData GetWaveData();
    }
}