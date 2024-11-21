// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveListConfig.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Modules.Wave.Config
{
    public interface IWaveListConfig
    {
        IReadOnlyList<IWaveData> GetListWaveConfig();
    }
    
    [CreateAssetMenu(
        fileName = "WaveListConfig",
        menuName = "SpaceShooter/Wave/WaveListConfig",
        order = 0)]
    internal sealed class WaveListConfig : ScriptableObject, IWaveListConfig
    {
        [SerializeField] private List<WaveConfig> listWaveConfig;

        public IReadOnlyList<IWaveData> GetListWaveConfig()
        {
            return listWaveConfig.Select(waveConfig => waveConfig.GetWaveData()).ToList();
        }
    }
}