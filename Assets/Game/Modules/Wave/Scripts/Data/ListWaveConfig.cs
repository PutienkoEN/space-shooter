// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: ListWaveConfig.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Game.Modules.Wave.Interface;
using UnityEngine;

namespace Game.Modules.Wave.Data
{
    [CreateAssetMenu(
        fileName = "ListWaveConfig",
        menuName = "SpaceShooter/Wave/ListWaveConfig",
        order = 0)]
    internal sealed class ListWaveConfig : ScriptableObject, IListWaveConfig
    {
        [SerializeField] private List<WaveConfig> listWaveConfig;

        public IReadOnlyList<IWaveData> GetListWaveConfig()
        {
            return listWaveConfig.Select(waveConfig => waveConfig.GetWaveData()).ToList();
        }
    }
}