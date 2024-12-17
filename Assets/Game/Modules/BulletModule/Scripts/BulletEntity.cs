using System;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule
{
    public sealed class BulletEntity : ISimpleEntity
    {
        public event Action<ISimpleEntity> OnDestroy;

        private readonly IBulletView _bulletView;
        private readonly MoveComponent _moveComponent;
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private readonly int _damage;
        private Vector3 _direction;

        [Inject]
        public BulletEntity(
            BulletView bulletView,
            MoveComponent moveComponent,
            BoundsCheckComponent boundsCheckComponent,
            int damage)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
            _boundsCheckComponent = boundsCheckComponent;
            _damage = damage;

            _bulletView.OnDealDamage += HandleOnDealDamage;
        }

        public void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _direction = direction;
            _bulletView.GetTransform().SetPositionAndRotation(position, rotation);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(_direction, deltaTime);
            if (!_boundsCheckComponent.OnScreen(_bulletView.GetCollider()))
            {
                Destroy();
            }
        }

        private void HandleOnDealDamage(IDamageable otherObject)
        {
            otherObject.TakeDamage(_damage);
            Destroy();
        }

        public void Destroy()
        {
            _bulletView.OnDealDamage -= HandleOnDealDamage;

            OnDestroy?.Invoke(this);

            //The check required for the unit test to work correctly.
            // Destroying in Edit Mode is not allowed.
            if (Application.isPlaying)
                _bulletView.Dispose();
        }
    }
}