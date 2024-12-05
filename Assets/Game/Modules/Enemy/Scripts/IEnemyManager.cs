using System;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyManager
    {
        public event Action<bool> OnEnemyChange;
        public EnemyEntity CreateEnemy(EnemyCreateData enemyCreateData);
        public void DestroyEnemy(EnemyEntity enemyEntity);
    }
}