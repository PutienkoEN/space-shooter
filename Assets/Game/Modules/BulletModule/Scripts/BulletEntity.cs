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

            _bulletView.OnCollision += HandleOnCollision;
        }

        // public void SetLayer(LayerMask layer)
        // {
        //     _bulletView.gameObject.layer = layer.value;
        // }
        
        private void HandleOnCollision(Collider collider)
        {
            Destroy();
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
                Destroy();
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
        
        private void Destroy()
        {
            _bulletView.OnCollision -= HandleOnCollision;
            
            OnDestroy?.Invoke(this);
            
            //The check required for the unit test to work correctly.
            // Destroying in Edit Mode is not allowed.
            if(Application.isPlaying) 
                _bulletView.DestroyBullet();
        }
        
        public class Factory : PlaceholderFactory<float, LayerMask, BulletEntity>
        {
        }
        
    }
}