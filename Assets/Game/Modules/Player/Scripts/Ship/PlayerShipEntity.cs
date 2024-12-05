using System;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipEntity : IInitializable, IDisposable
    {
        private readonly IPlayerShipView _playerShipView;
        private readonly PlayerMoveController _playerMoveController;
        private readonly WeaponController _weaponController;

        private readonly HealthComponent _healthComponent;

        [Inject]
        public PlayerShipEntity(
            IPlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            WeaponController weaponController,
            HealthComponent healthComponent)
        {
            _playerShipView = playerShipView;
            _playerMoveController = playerMoveController;
            _weaponController = weaponController;
            _healthComponent = healthComponent;
        }

        public void Initialize()
        {
            _playerShipView.OnTakeDamage += TakeDamage;
        }

        public void Dispose()
        {
            _playerShipView.Destroy();
        }

        public void Update(float deltaTime)
        {
            _playerMoveController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
        }

        public void TakeDamage(int damage)
        {
            _healthComponent.TakeDamage(damage);
        }

        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}