// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyConfig.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    [CreateAssetMenu(
        fileName = "EnemyConfig",
        menuName = "SpaceShooter/Enemy/EnemyConfig")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private EnemyView enemyPrefab;

        [SerializeField] private int health;
        [SerializeField] private float speed;
        [SerializeField] private int collisionDamage;
        [SerializeField] private long scoreAward;

        public EnemyData GetData() => new(enemyPrefab, health, speed, collisionDamage, scoreAward);
    }

    public struct EnemyData
    {
        public EnemyView EnemyPrefab { get; private set; }
        public int Health { get; private set; }
        public float Speed { get; private set; }
        public int CollisionDamage { get; private set; }
        public long ScoreAward { get; private set; }

        public EnemyData(EnemyView enemyPrefab, int health, float speed, int collisionDamage, long scoreAward)
        {
            EnemyPrefab = enemyPrefab;
            Health = health;
            Speed = speed;
            CollisionDamage = collisionDamage;
            ScoreAward = scoreAward;
        }
    }
}