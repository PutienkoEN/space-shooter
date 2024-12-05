using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerGameStartListener : IGameStartListener
    {
        private readonly PlayerManager _playerManager;

        [Inject]
        public PlayerGameStartListener(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public void OnGameStart()
        {
            _playerManager.CreatePlayer();
        }
    }
}