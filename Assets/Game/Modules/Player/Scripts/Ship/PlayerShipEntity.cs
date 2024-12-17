using System;
using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public sealed class PlayerShipEntity : IInitializable, IDisposable, IPlayerShipEntity
    {
        public event Action<bool> OnInGameStateChanged;
        
        private readonly IPlayerShipView _playerShipView;
        private readonly PlayerMoveController _playerMoveController;
        private readonly IWeaponController _weaponController;
        private bool _isAlive;

        [Inject]
        public PlayerShipEntity(
            IPlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            IWeaponController weaponController)
        {
            _playerShipView = playerShipView;
            _playerMoveController = playerMoveController;
            _weaponController = weaponController;
        }

        public void Initialize()
        {
            SetIsAlive(true);
        }
        
        public void SetIsAlive(bool value)
        {
            if (_isAlive == value)
            {
                return;
            }
            _isAlive = value;
            OnInGameStateChanged?.Invoke(value);
        }
        
        public Transform GetTransform()
        {
            return _playerShipView.GetTransform();
        }

        public void ChangeWeapon(WeaponData weaponData)
        {
            _weaponController.ChangeWeapon(weaponData);
        }
        
        public void OnUpdate(float deltaTime)
        {
            if (!_isAlive)
                return;
            _playerMoveController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
        }
        
        public void Dispose()
        {
            _playerShipView.Dispose();
        }
        
        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}