using System;
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
        public event Action<EnemyEntity> OnLeftGameArea;

        public readonly HealthComponent HealthComponent;
        private readonly SplineMoveController _splineMoveController;
        private readonly BoundsCheckComponent _boundsCheckComponent;

        private readonly IEnemyView _enemyView;

        [Button]
        public void TakeDamage(int damage)
        {
            HealthComponent.TakeDamage(damage);
        }

        public EnemyEntity(
            HealthComponent healthComponent,
            SplineMoveController splineMoveController,
            BoundsCheckComponent boundsCheckComponent,
            IEnemyView enemyView)
        {
            HealthComponent = healthComponent;
            _splineMoveController = splineMoveController;
            _boundsCheckComponent = boundsCheckComponent;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            _enemyView.OnDealDamage += DealCollisionDamage;
            _enemyView.OnTakeDamage += HandleTakeTakeDamage;

            _splineMoveController.StartMove();
        }

        private void DealCollisionDamage(IDamageable damageable)
        {
            damageable.TakeDamage(5);
        }

        public void Dispose()
        {
            _enemyView.OnTakeDamage -= HandleTakeTakeDamage;
            _enemyView.Destroy();
        }

        public void Update(float deltaTime)
        {
            if (_boundsCheckComponent.LeftGameArea(_enemyView.GetCollider()))
            {
                OnLeftGameArea?.Invoke(this);
            }
        }

        private void HandleTakeTakeDamage(int damage)
        {
            Debug.Log("in HandleTakeTakeDamage");
            HealthComponent.TakeDamage(damage);
        }


        public class Factory : PlaceholderFactory<EnemyCreateData, EnemyEntity>
        {
        }
    }
}