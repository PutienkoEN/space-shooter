using System;
using Game.Modules.BulletModule.Scripts;
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
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private Collider _collider;

        [Button]
        public void TakeDamage(float damage)
        {
            HealthComponent.TakeDamage(damage);
        }

        [Inject]
        public EnemyEntity(
            HealthComponent healthComponent, 
            MoveComponent moveComponent, 
            IEnemyView enemyView, 
            BoundsCheckComponent boundsCheckComponent)
        {
            HealthComponent = healthComponent;
            _moveComponent = moveComponent;
            _enemyView = enemyView;
            _boundsCheckComponent = boundsCheckComponent;

            _collider = _enemyView.GetCollider();
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
            if (!_boundsCheckComponent.IsInBounds(_collider))
            {
                Debug.Log("is out of bounds ");
            }
        }


        public class Factory : PlaceholderFactory<Vector3, Quaternion, EnemyData, EnemyEntity>
        {
        }
    }
}