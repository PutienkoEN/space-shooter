﻿using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyManager : IEnemyManager, IGameTickable
    {
        private readonly EnemyEntity.Factory _enemyFactory;
        private readonly List<EnemyEntity> _enemies = new();

        [Inject]
        public EnemyManager(EnemyEntity.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void Tick(float deltaTime)
        {
            foreach (var enemy in _enemies)
            {
                enemy.Update(deltaTime);
            }
        }

        public EnemyEntity CreateEnemy(Vector3 position, Quaternion rotation, EnemyData enemyData)
        {
            var enemyEntity = _enemyFactory.Create(position, rotation, enemyData);
            enemyEntity.Initialize();
            _enemies.Add(enemyEntity);

            return enemyEntity;
        }

        public void DestroyEnemy(EnemyEntity enemyEntity)
        {
            _enemies.Remove(enemyEntity);
            enemyEntity.Dispose();
        }
    }
}