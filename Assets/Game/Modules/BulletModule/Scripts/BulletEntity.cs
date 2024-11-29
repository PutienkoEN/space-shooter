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
        private readonly CollisionProcessor _collisionProcessor;
        private Vector3 _direction;
        private int _damage;
        
        [Inject]
        public BulletEntity(
            BulletView bulletView, 
            MoveComponent moveComponent, 
            BoundsCheckComponent boundsCheckComponent, 
            CollisionProcessor collisionProcessor)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
            _boundsCheckComponent = boundsCheckComponent;
            _collisionProcessor = collisionProcessor;
            _collider = _bulletView.GetComponent<Collider>();

            _bulletView.OnCollision += HandleOnCollision;
        }

        public void LaunchBullet(Vector3 position, Quaternion rotation, Vector3 direction, int damage)
        {
            _direction = direction;
            _damage = damage;
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
        
        private void HandleOnCollision(Collider otherObject)
        {
            if(otherObject.gameObject.TryGetComponent<IDamagable>(out IDamagable damagable))
            {
                Debug.Log("found damagable");
                var colliderObject = new ColliderObject(_bulletView.gameObject.layer, _damage);
                var collisionEvent = new CollisionEvent(colliderObject, damagable);
                _collisionProcessor.AddCollisionEvent(collisionEvent);
            }
           
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