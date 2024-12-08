using Game.Modules.GameSpeed;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.Game
{
    public class PauseGameFinishListener : IGameStartListener, IGameFinishListener
    {
        private readonly IGameSpeedManager _gameSpeedManager;

        [Inject]
        public PauseGameFinishListener(IGameSpeedManager gameSpeedManager)
        {
            _gameSpeedManager = gameSpeedManager;
        }

        public void OnGameStart()
        {
            _gameSpeedManager.SetSlowdown();
        }

        public void OnGameFinish()
        {
            _gameSpeedManager.StopTime();
        }
    }
}