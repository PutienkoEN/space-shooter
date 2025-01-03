﻿using System;
using System.Collections.Generic;
using Game.Modules.AnimationModule.Scripts;
using Game.Modules.Common.Interfaces;
using ModestTree;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public sealed class EnemyManager : IEnemyManager, IGameTickable
    {
        public event Action<bool> OnEnemyChange;

        private readonly EnemyEntityFactory _enemyFactory;
        private readonly List<IEnemyEntity> _enemies = new();

        [Inject]
        public EnemyManager(
            EnemyEntityFactory enemyFactory,
            EffectsAnimator effectsAnimator)
        {
            _enemyFactory = enemyFactory;
        }

        public void Tick(float deltaTime)
        {
            for (var enemyIndex = _enemies.Count - 1; enemyIndex >= 0; enemyIndex--)
            {
                var enemyEntity = _enemies[enemyIndex];
                enemyEntity.OnUpdate(deltaTime);
            }
        }

        public IEnemyEntity CreateEnemy(EnemyCreateData enemyCreateData)
        {
            var enemyEntity = SetupEnemy(enemyCreateData);

            _enemies.Add(enemyEntity);
            OnEnemyChange?.Invoke(HasEnemies());

            return enemyEntity;
        }

        private EnemyEntity SetupEnemy(EnemyCreateData enemyCreateData)
        {
            var enemyEntity = _enemyFactory.Create(enemyCreateData);

            enemyEntity.Initialize();
            enemyEntity.OnLeftGameArea += DestroyEnemy;

            return enemyEntity;
        }

        public void DestroyEnemy(IEnemyEntity enemyEntity)
        {
            _enemies.Remove(enemyEntity);
            DisposeEnemy(enemyEntity);
            OnEnemyChange?.Invoke(HasEnemies());
        }

        private void DisposeEnemy(IEnemyEntity enemyEntity)
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