using System;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyManager
    {
        public event Action<bool> OnEnemyChange;
        public EnemyEntity CreateEnemy(Vector3 position, Quaternion rotation, EnemyData enemyData);
        public void DestroyEnemy(EnemyEntity enemyEntity);
    }
}