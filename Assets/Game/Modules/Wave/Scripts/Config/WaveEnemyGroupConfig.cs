// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveEnemyGroupConfig.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using Game.Modules.Enemy.Scripts;
using UnityEngine;

namespace Game.Modules.Wave.Config
{
    [CreateAssetMenu(
        fileName = "WaveEnemyGroupConfig",
        menuName = "SpaceShooter/Wave/WaveEnemyGroupConfig")]
    public sealed class WaveEnemyGroupConfig : WaveConfig
    {
        [SerializeField] private List<EnemyGroupConfig> listEnemyGroupConfig;
        
        public override IWaveData GetWaveData()
        {
            var list = listEnemyGroupConfig.Select(enemyGroupConfig => enemyGroupConfig.GetEnemyGroupData()).ToList();

            return new WaveEnemyGroupData(list);
        }
    }

    public struct WaveEnemyGroupData : IWaveData
    {
        public IReadOnlyList<EnemyGroupData> listEnemyGroupData { get; private set; }
        
        public WaveEnemyGroupData(IReadOnlyList<EnemyGroupData> listEnemyGroupData)
        {
            this.listEnemyGroupData = listEnemyGroupData;
        }
    }
}