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

        public BulletEntity(BulletView bulletView, MoveComponent moveComponent)
        {
            _bulletView = bulletView;
            _moveComponent = moveComponent;
        }

        public BulletView GetView()
        {
            return _bulletView;
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.Move(_target, deltaTime);
        }
        
        public class Factory : PlaceholderFactory<float, BulletEntity>
        {
        }
        
    }
}