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
        private readonly EffectsAnimator _effectsAnimator;

        [Inject]
        public PlayerDeathController(
            PlayerShipEntity playerEntity, 
            PlayerManager playerManager, 
            EffectsAnimator effectsAnimator)
        {
            _playerEntity = playerEntity;
            _playerManager = playerManager;
            _effectsAnimator = effectsAnimator;

            _playerEntity.HealthComponent.OnDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            _effectsAnimator.PlayExplosion(_playerEntity.GetCurrentPosition(), DestroyPlayer);
        }
        private void DestroyPlayer()
        {
            _playerManager.DestroyPlayer();
            _playerEntity.HealthComponent.OnDeath -= DestroyPlayer;
        }
    }
}