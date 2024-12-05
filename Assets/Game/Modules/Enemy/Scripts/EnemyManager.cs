using System;
using System.Collections.Generic;
using ModestTree;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyManager : IEnemyManager, IGameTickable
    {
        public event Action<bool> OnEnemyChange;

        private readonly EnemyEntity.Factory _enemyFactory;
        private readonly List<EnemyEntity> _enemies = new();

        [Inject]
        public EnemyManager(EnemyEntity.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Tick(float deltaTime)
        {
            for (var enemyIndex = _enemies.Count - 1; enemyIndex >= 0; enemyIndex--)
            {
                var enemyEntity = _enemies[enemyIndex];
                enemyEntity.Update(deltaTime);
            }
        }

        public EnemyEntity CreateEnemy(Vector3 position, Quaternion rotation, EnemyData enemyData)
        {
            var enemyEntity = SetupEnemy(position, rotation, enemyData);

            _enemies.Add(enemyEntity);
            OnEnemyChange?.Invoke(HasEnemies());

            return enemyEntity;
        }

        private EnemyEntity SetupEnemy(Vector3 position, Quaternion rotation, EnemyData enemyData)
        {
            var enemyEntity = _enemyFactory.Create(position, rotation, enemyData);

            enemyEntity.Initialize();
            enemyEntity.OnLeftGameArea += DestroyEnemy;

            return enemyEntity;
        }

        public void DestroyEnemy(EnemyEntity enemyEntity)
        {
            _enemies.Remove(enemyEntity);
            DisposeEnemy(enemyEntity);

            OnEnemyChange?.Invoke(HasEnemies());
        }

        private void DisposeEnemy(EnemyEntity enemyEntity)
        {
            enemyEntity.OnLeftGameArea -= DestroyEnemy;
            enemyEntity.Dispose();
        }

        private bool HasEnemies()
        {
            return !_enemies.IsEmpty();
        }
    }
}