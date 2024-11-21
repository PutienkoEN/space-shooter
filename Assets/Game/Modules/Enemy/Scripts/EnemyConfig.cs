// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyConfig.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    [CreateAssetMenu(
        fileName = "EnemyConfig",
        menuName = "SpaceShooter/Enemy/EnemyConfig")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyView enemyPrefab;

        public EnemyData GetEnemyData() => new EnemyData(enemyPrefab);
    }

    public struct EnemyData
    {
        public EnemyView enemyPrefab { get; private set; }

        public EnemyData(EnemyView enemyPrefab)
        {
            this.enemyPrefab = enemyPrefab;
        }
    }
}