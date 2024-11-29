using System;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletEntity
    {
        public event Action<BulletEntity> OnDestroy;
        
        private readonly BulletView _bulletView;
        private readonly MoveComponent _moveComponent;
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private readonly Collider _collider;
        private Vector3 _direction;
        
        [Inject]
        public BulletEntity(
            BulletView bulletView, 
            MoveComponent moveComponent, 
            BoundsCheckComponent boundsCheckComponent)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
            _boundsCheckComponent = boundsCheckComponent;
            _collider = _bulletView.GetComponent<Collider>();

            _bulletView.OnCollision += HandleOnCollision;
        }

        public void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _direction = direction;
            _bulletView.transform.SetPositionAndRotation(position, rotation);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(_direction, deltaTime);
            if (!_boundsCheckComponent.IsInBounds(_collider))
            {
                Destroy();
            }
        }
        
        private void HandleOnCollision(Collider collider)
        {
            Destroy();
        }
        
        private void Destroy()
        {
            _bulletView.OnCollision -= HandleOnCollision;
            
            OnDestroy?.Invoke(this);
            
            //The check required for the unit test to work correctly.
            // Destroying in Edit Mode is not allowed.
            if(Application.isPlaying) 
                _bulletView.DestroyBullet();
        }
        
        public class Factory : PlaceholderFactory<float, int, BulletEntity>
        {
        }
        
    }
}