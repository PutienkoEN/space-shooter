using Game.Modules.GameSpeed;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.Game
{
    public class PauseGameFinishListener : IGameFinishListener
    {
        private readonly IGameSpeedManager _gameSpeedManager;

        [Inject]
        public PauseGameFinishListener(IGameSpeedManager gameSpeedManager)
        {
            _gameSpeedManager = gameSpeedManager;
        }

        public void OnGameFinish()
        {
            _gameSpeedManager.StopTime();
        }
    }
}