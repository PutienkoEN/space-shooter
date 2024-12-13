using System;
using Game.Modules.Common.Interfaces;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyManager
    {
        public event Action<bool> OnEnemyChange;
        public EnemyEntity CreateEnemy(EnemyCreateData enemyCreateData);
        public void DestroyEnemy(IEnemyEntity enemyEntity);
    }
}