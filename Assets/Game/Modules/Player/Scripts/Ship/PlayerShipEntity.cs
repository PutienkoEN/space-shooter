using System;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipEntity : IDisposable
    {
        private readonly PlayerShipView _playerShipView;
        private readonly PlayerMoveController _playerMoveController;
        private readonly WeaponController _weaponController;
        private readonly BulletController _bulletController;

        private readonly HealthComponent _healthComponent;

        [Inject]
        public PlayerShipEntity(
            PlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            [InjectOptional] WeaponController weaponController,
            [InjectOptional] BulletController bulletController,
            HealthComponent healthComponent)
        {
            _playerShipView = playerShipView;
            _playerMoveController = playerMoveController;
            _weaponController = weaponController;
            _bulletController = bulletController;
            _healthComponent = healthComponent;
        }

        public void TakeDamage(float damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        public void Update(float deltaTime)
        {
            _playerMoveController.Move(deltaTime);
            
            _weaponController?.Tick(deltaTime);
            _bulletController?.Tick(deltaTime);
        }

        public void Dispose()
        {
            _playerShipView.DestroyShip();
        }

        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}