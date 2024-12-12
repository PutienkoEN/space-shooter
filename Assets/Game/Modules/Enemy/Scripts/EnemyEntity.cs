using System;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
using Game.Modules.Components;
using Game.Modules.ShootingModule.Scripts;
using Sirenix.OdinInspector;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    [Serializable]
    public class EnemyEntity : IInitializable, IDisposable, IEntity
    {
        public event Action<EnemyEntity> OnLeftGameArea;

        public readonly HealthComponent HealthComponent;
        private readonly SplineMoveController _splineMoveController;
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private readonly CollisionDamageComponent _collisionDamageComponent;
        private readonly WeaponController _weaponController;
        private readonly IEnemyView _enemyView;

        [Button]
        public void TakeDamage(int damage)
        {
            HealthComponent.TakeDamage(damage);
        }

        [Inject]
        public EnemyEntity(
            HealthComponent healthComponent,
            SplineMoveController splineMoveController,
            BoundsCheckComponent boundsCheckComponent,
            CollisionDamageComponent collisionDamageComponent,
            WeaponController weaponController,
            IEnemyView enemyView)
        {
            HealthComponent = healthComponent;
            _splineMoveController = splineMoveController;
            _boundsCheckComponent = boundsCheckComponent;
            _collisionDamageComponent = collisionDamageComponent;
            _weaponController = weaponController;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            _enemyView.OnDealDamage += DealCollisionDamage;
            _enemyView.OnTakeDamage += HandleTakeDamage;

            _splineMoveController.StartMove();
        }

        private void DealCollisionDamage(IDamageable damageable)
        {
            _collisionDamageComponent.DealDamage(damageable);
        }

        public void Dispose()
        {
            _enemyView.OnTakeDamage -= HandleTakeDamage;
            _enemyView.Dispose();
        }

        public void Update(float deltaTime)
        {
            if (_boundsCheckComponent.LeftGameArea(_enemyView.GetCollider()))
            {
                OnLeftGameArea?.Invoke(this);
            }
            _weaponController.Tick(deltaTime);
        }

        private void HandleTakeDamage(int damage)
        {
            HealthComponent.TakeDamage(damage);
        }
    }
}