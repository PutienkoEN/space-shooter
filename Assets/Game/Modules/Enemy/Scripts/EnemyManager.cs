using System;
using System.Collections.Generic;
using Game.Modules.AnimationModule.Scripts;
using Game.Modules.Common.Interfaces;
using ModestTree;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public sealed class EnemyManager : IEnemyManager, IGameTickable
    {
        public event Action<bool> OnEnemyChange;

        private readonly EnemyEntity.Factory _enemyFactory;
        private readonly List<IEntity> _enemies = new();
        private EffectsAnimator _effectsAnimator;
        private int _destructionCounter;

        [Inject]
        public EnemyManager(
            EnemyEntity.Factory enemyFactory, 
            EffectsAnimator effectsAnimator)
        {
            _enemyFactory = enemyFactory;
            _effectsAnimator = effectsAnimator;
        }

        public void Tick(float deltaTime)
        {
            for (var enemyIndex = _enemies.Count - 1; enemyIndex >= 0; enemyIndex--)
            {
                var enemyEntity = _enemies[enemyIndex];
                enemyEntity.Update(deltaTime);
            }
        }

        public EnemyEntity CreateEnemy(EnemyCreateData enemyCreateData)
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

        public void DestroyEnemy(EnemyEntity enemyEntity)
        {
            _destructionCounter++;
            
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