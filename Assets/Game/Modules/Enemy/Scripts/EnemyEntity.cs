using System;
using Sirenix.OdinInspector;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    [Serializable]
    public class EnemyEntity : IInitializable, IDisposable
    {
        public readonly HealthComponent HealthComponent;

        private readonly MoveComponent _moveComponent;
        private readonly IEnemyView _enemyView;

        [Button]
        public void TakeDamage(float damage)
        {
            HealthComponent.TakeDamage(damage);
        }

        [Inject]
        public EnemyEntity(HealthComponent healthComponent, MoveComponent moveComponent, IEnemyView enemyView)
        {
            HealthComponent = healthComponent;
            _moveComponent = moveComponent;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            // Required to be called directly since it's in sub-container 
        }

        public void Dispose()
        {
            // Required to be called directly since it's in sub-container
            _enemyView.Destroy();
        }

        public void Update(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }


        public class Factory : PlaceholderFactory<Vector3, Quaternion, EnemyData, EnemyEntity>
        {
        }
    }
}