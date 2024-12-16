using System;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerManager : IGameTickable, IPlayerPositionProvider
    {
        public event Action OnPlayerDeath;

        private readonly PlayerShipEntity.Factory _shipEntityFactory;
        private PlayerShipEntity _playerShipEntity;

        [Inject]
        public PlayerManager(
            PlayerShipEntity.Factory shipEntityFactory)
        {
            _shipEntityFactory = shipEntityFactory;
        }

        public PlayerShipEntity CreatePlayer()
        {
            _playerShipEntity = _shipEntityFactory.Create();
            _playerShipEntity.Initialize();

            return _playerShipEntity;
        }

        public PlayerShipEntity GetPlayer()
        {
            return _playerShipEntity;
        }

        public Transform GetTransform()
        {
            return _playerShipEntity?.GetTransform();
        }

        public void DestroyPlayer()
        {
            _playerShipEntity.Dispose();
            _playerShipEntity = null;
            OnPlayerDeath?.Invoke();
        }

        public void Tick(float deltaTime)
        {
            if (_playerShipEntity != null)
            {
                _playerShipEntity.OnUpdate(deltaTime);
            }
        }
    }
}