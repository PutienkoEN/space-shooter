using Game.Modules.LevelInterfaces.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelGameStartListener : IGameStartListener
    {
        private readonly LevelEventManager _levelEventManager;
        private readonly LevelManager _levelManager;

        public LevelGameStartListener(LevelEventManager levelEventManager, LevelManager levelManager)
        {
            _levelEventManager = levelEventManager;
            _levelManager = levelManager;
        }

        public void OnGameStart()
        {
            var levelConfig = _levelManager.GetLevel();
            _levelEventManager.StartLevel(levelConfig);
        }
    }
}