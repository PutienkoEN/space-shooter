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
        private Rect _colliderRect;
        
        public BulletEntity(
            BulletView bulletView, 
            MoveComponent moveComponent, 
            BoundsCheckComponent boundsCheckComponent)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
            _boundsCheckComponent = boundsCheckComponent;
            _collider = _bulletView.GetComponent<Collider>();

            OnDestroy += HandleDestroy;
        }

        public void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction)
        {
            _direction = direction;
            _bulletView.transform.SetPositionAndRotation(position, rotation);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(_direction, deltaTime);
            if (!_boundsCheckComponent.IsInBounds(GetColliderRect()))
            {
                OnDestroy?.Invoke(this);
            }
        }

        public Rect GetColliderRect()
        {
            if (_collider != null)
            {
                Bounds colliderBounds = _collider.bounds;
                if (_colliderRect == Rect.zero)
                {
                    _colliderRect = new Rect(
                        colliderBounds.min.x,
                        colliderBounds.min.y,
                        colliderBounds.size.x,
                        colliderBounds.size.y);
                }
                else
                {
                    _colliderRect.x = colliderBounds.min.x;
                    _colliderRect.y = colliderBounds.min.y;
                    _colliderRect.width = colliderBounds.size.x;
                    _colliderRect.height = colliderBounds.size.y;
                }
            }
            
            return _colliderRect;
        }
        
        private void HandleDestroy(BulletEntity _)
        {
            //The check required for the unit test to work correctly.
            // Destroying in Edit Mode is no allowed.
            if(Application.isPlaying) 
                _bulletView.DestroyBullet();
        }
        
        public class Factory : PlaceholderFactory<float, BulletEntity>
        {
        }
        
    }
}