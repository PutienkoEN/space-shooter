using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    public class GameStartObserver : ITickable
    {
        private readonly IGameContext _gameContext;
        private readonly IGameManager _gameManager;

        private bool _isGameStartTriggered;

        [Inject]
        public GameStartObserver(IGameContext gameContext, IGameManager gameManager)
        {
            _gameContext = gameContext;
            _gameManager = gameManager;
        }

        public void Tick()
        {
            if (_isGameStartTriggered)
            {
                return;
            }

            if (_gameContext.GameStart)
            {
                _gameManager.StartGame();
            }
        }
    }
}