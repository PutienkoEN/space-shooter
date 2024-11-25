using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletEntity
    {
        private readonly BulletView _bulletView;
        private readonly MoveComponent _moveComponent;
        private readonly Vector3 _target = Vector3.up;
        private readonly Collider _collider;
        private Rect _colliderRect;

        public BulletEntity(BulletView bulletView, MoveComponent moveComponent)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
            _collider = _bulletView.GetComponent<Collider>();
        }

        public BulletView GetView()
        {
            return _bulletView;
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.Move(_target, deltaTime);
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
        
        public class Factory : PlaceholderFactory<float, BulletEntity>
        {
        }
        
    }
}