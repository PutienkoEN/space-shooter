using System;
using Game.Modules.ShootingModule.Scripts;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipEntity : IDisposable
    {
        private readonly PlayerShipView _playerShipView;
        private readonly PlayerMovementController _playerMovementController;
        private readonly WeaponController _weaponController;

        [Inject]
        public PlayerShipEntity(PlayerShipView playerShipView, PlayerMovementController playerMovementController,
            WeaponController weaponController)
        {
            _playerShipView = playerShipView;
            _playerMovementController = playerMovementController;
            _weaponController = weaponController;
        }

        public void Update(float deltaTime)
        {
            _playerMovementController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
        }

        public void Dispose()
        {
            Object.Destroy(_playerShipView.gameObject);
        }

        public void Initialize()
        {
            Debug.Log("PlayerShipEntity.Initialize");
        }

        public void Tick()
        {
            Debug.Log("PlayerShipEntity.Tick");
        }

        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}