using System;
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
        private EffectsAnimator _effectsAnimator;

        [Inject]
        public PlayerManager(
            PlayerShipEntity.Factory shipEntityFactory, 
            EffectsAnimator effectsAnimator)
        {
            _shipEntityFactory = shipEntityFactory;
            _effectsAnimator = effectsAnimator;
        }


        public PlayerShipEntity CreatePlayer()
        {
            _playerShipEntity = _shipEntityFactory.Create();
            _playerShipEntity.Initialize();

            return _playerShipEntity;
        }

        public void DestroyPlayer()
        {
            if (_effectsAnimator != null)
            {
                _effectsAnimator.PlayExplosion(_playerShipEntity.GetCurrentPosition(), OnPlayerDeath);
            }
            else
            {
                OnPlayerDeath?.Invoke();
            }
            _playerShipEntity.Dispose();
            _playerShipEntity = null;

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