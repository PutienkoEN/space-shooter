using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletEntity
    {
        private readonly BulletView _bulletView;
        private readonly MoveComponent _moveComponent;
        private readonly Vector3 _direction = Vector3.up;

        public BulletEntity(BulletView bulletView, MoveComponent moveComponent)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
        }

        public BulletView GetView()
        {
            return _bulletView;
        }

        public void LaunchBullet(Vector3 position, Quaternion rotation)
        {
            _bulletView.transform.SetPositionAndRotation(position, rotation);
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(_direction, deltaTime);
        }
        
        public class Factory : PlaceholderFactory<float, BulletEntity>
        {
        }
        
    }
}