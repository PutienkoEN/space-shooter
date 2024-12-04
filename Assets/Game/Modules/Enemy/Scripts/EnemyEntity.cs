using System;
using Game.Modules.AnimationModule.Scripts;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
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
        private readonly IDamagable _damagable;
        private readonly ICollidable _collidable;
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private Collider _collider;
        
        private EffectsAnimator _effectsAnimator;

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
            IDamagable damagable,
            BoundsCheckComponent boundsCheckComponent)
        {
            HealthComponent = healthComponent;
            _moveComponent = moveComponent;
            _enemyView = enemyView;
            _damagable = damagable;
            _boundsCheckComponent = boundsCheckComponent;

            _collider = _enemyView.GetCollider();
            
            _damagable.OnTakeDamage += HandleTakeDamage;

            _effectsAnimator = new EffectsAnimator();
        }

        private void HandleTakeDamage(int damage)
        {
            Debug.Log("in HandleTakeDamage");
            HealthComponent.TakeDamage(damage);
        }

        public void Initialize()
        {
            // Required to be called directly since it's in sub-container 
        }

        public void Dispose()
        {
            _damagable.OnTakeDamage -= HandleTakeDamage;
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