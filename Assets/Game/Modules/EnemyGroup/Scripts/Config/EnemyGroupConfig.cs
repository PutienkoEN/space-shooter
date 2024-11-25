// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyGroupConfig.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    [CreateAssetMenu(
        fileName = "EnemyGroupConfig",
        menuName = "SpaceShooter/Enemy/EnemyGroupConfig")]
    public sealed class EnemyGroupConfig : ScriptableObject
    {
        [SerializeField] private List<EnemyConfig> listEnemyConfig;

        public EnemyGroupData GetEnemyGroupData()
        {
            var list = listEnemyConfig.Select(enemyConfig => enemyConfig.GetData()).ToList();
            return new EnemyGroupData(list);
        }
    }

    public struct EnemyGroupData
    {
        public IReadOnlyList<EnemyData> ListEnemyData { get; private set; }

        public EnemyGroupData(IReadOnlyList<EnemyData> listEnemyData)
        {
            this.ListEnemyData = listEnemyData;
        }
    }
}