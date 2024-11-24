using System;
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

        private readonly HealthComponent _healthComponent;

        [Inject]
        public PlayerShipEntity(
            PlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            WeaponController weaponController,
            HealthComponent healthComponent)
        {
            _playerShipView = playerShipView;
            _playerMoveController = playerMoveController;
            _weaponController = weaponController;
            _healthComponent = healthComponent;
        }

        public void TakeDamage(float damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        public void Update(float deltaTime)
        {
            _playerMoveController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
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