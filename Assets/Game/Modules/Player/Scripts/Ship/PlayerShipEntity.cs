using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public sealed class PlayerShipEntity : IInitializable, IDisposable, IEntity
    {
        public event Action<bool> OnInGameStateChanged;
        
        private readonly IPlayerShipView _playerShipView;
        private readonly PlayerMoveController _playerMoveController;
        private readonly WeaponController _weaponController;
        private bool _isAlive;



        [Inject]
        public PlayerShipEntity(
            IPlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            WeaponController weaponController)
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

        public void Dispose()
        {
            _playerShipView.Dispose();
        }

        public void Update(float deltaTime)
        {
            if (!_isAlive)
                return;
            _playerMoveController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
        }
        
        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}