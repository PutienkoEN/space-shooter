using Game.Modules.AnimationModule.Scripts;
using SpaceShooter.Game.Components;
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
        private readonly HealthComponent _healthComponent;

        [Inject]
        public PlayerDeathController(
            PlayerShipEntity playerEntity,
            PlayerShipView playerShipView,
            PlayerManager playerManager, 
            EffectsAnimator effectsAnimator,
            HealthComponent healthComponent)
        {
            _playerEntity = playerEntity;
            _playerShipView = playerShipView;
            _playerManager = playerManager;
            _effectsAnimator = effectsAnimator;
            _healthComponent = healthComponent;

            _healthComponent.OnDeath += OnPlayerDeath;
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
            _healthComponent.OnDeath -= DestroyPlayer;
        }
    }
}