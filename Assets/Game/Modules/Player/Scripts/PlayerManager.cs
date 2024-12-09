﻿using System;
using Game.Modules.AnimationModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player.Ship;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerManager : IGameTickable
    {
        public event Action OnPlayerDeath;

        private PlayerShipEntity.Factory _shipEntityFactory;
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
                _playerShipEntity.Update(deltaTime);
            }
        }
    }
}