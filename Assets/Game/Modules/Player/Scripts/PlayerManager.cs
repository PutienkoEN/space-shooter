using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player.Ship;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerManager : IGameTickable
    {
        private PlayerShipEntity.Factory _shipEntityFactory;
        private PlayerShipEntity _playerShipEntity;

        [Inject]
        public void Construct(PlayerShipEntity.Factory shipEntityFactory)
        {
            _shipEntityFactory = shipEntityFactory;
        }

        public void CreatePlayer()
        {
            _playerShipEntity = _shipEntityFactory.Create();
        }

        public void DestroyPlayer()
        {
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