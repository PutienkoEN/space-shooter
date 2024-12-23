using SpaceShooter.Game.LifeCycle.Common;

namespace SpaceShooter.Game.Level
{
    public class LevelGameStartListener : IGameStartListener, IGameFinishListener
    {
        private readonly LevelManager _levelManager;
        private readonly LevelEventManager _levelEventManager;

        public LevelGameStartListener(
            LevelManager levelManager,
            LevelEventManager levelEventManager)
        {
            _levelManager = levelManager;
            _levelEventManager = levelEventManager;
        }

        public void OnGameStart()
        {
            var levelConfig = _levelManager.GetLevelConfig();
            _levelEventManager.StartLevel(levelConfig);
        }

        public void OnGameFinish()
        {
            _levelManager.FinishCurrentLevel();
        }
    }
}