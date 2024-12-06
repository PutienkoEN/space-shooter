using Game.Modules.AnimationModule.Scripts;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerDeathController
    {
        private readonly PlayerShipEntity _playerEntity;
        private readonly PlayerManager _playerManager;

        [Inject]
        public PlayerDeathController(
            PlayerShipEntity playerEntity, 
            PlayerManager playerManager)
        {
            _playerEntity = playerEntity;
            _playerManager = playerManager;

            _playerEntity.HealthComponent.OnDeath += DestroyPlayer;
        }

        private void DestroyPlayer()
        {
            _playerManager.DestroyPlayer();
            _playerEntity.HealthComponent.OnDeath -= DestroyPlayer;
        }
    }
}