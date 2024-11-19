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
        [SerializeField] private EnemyView enemyView;

        public EnemyData GetEnemyData() => new EnemyData(enemyView);
    }

    public struct EnemyData
    {
        public EnemyView enemyView { get; private set; }

        public EnemyData(EnemyView enemyView)
        {
            this.enemyView = enemyView;
        }
    }
}