using Game.Modules.AnimationModule.Scripts;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerDeathController
    {
        private readonly PlayerShipEntity _playerEntity;
        private readonly PlayerShipView _playerShipView;
        private readonly PlayerManager _playerManager;
        private readonly EffectsAnimator _effectsAnimator;

        [Inject]
        public PlayerDeathController(
            PlayerShipEntity playerEntity,
            PlayerShipView playerShipView,
            PlayerManager playerManager, 
            EffectsAnimator effectsAnimator)
        {
            _playerEntity = playerEntity;
            _playerShipView = playerShipView;
            _playerManager = playerManager;
            _effectsAnimator = effectsAnimator;

            _playerEntity.HealthComponent.OnDeath += OnPlayerDeath;
        }

        private void OnPlayerDeath()
        {
            _playerEntity.SetIsAlive(false);
            _playerShipView.SetActive(false);
            _effectsAnimator.PlayExplosion(_playerShipView.GetTransform(), DestroyPlayer);
        }
        
        private void DestroyPlayer()
        {
            _playerManager.DestroyPlayer();
            _playerEntity.HealthComponent.OnDeath -= DestroyPlayer;
        }
    }
}