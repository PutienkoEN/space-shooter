using Game.Modules.LevelInterfaces.Scripts;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelManager
    {
        private readonly LevelEventManager _levelEventManager;
        private readonly ILevelProvider _levelProvider;

        [Inject]
        public LevelManager(LevelEventManager levelEventManager, ILevelProvider levelProvider)
        {
            _levelEventManager = levelEventManager;
            _levelProvider = levelProvider;
        }

        public void StartLevel()
        {
            var levelConfig = _levelProvider.GetLevelConfig();
            _levelEventManager.StartLevel(levelConfig.GetData());
        }

        public void StartLevel(LevelConfig levelConfig)
        {
            _levelEventManager.StartLevel(levelConfig.GetData());
        }
    }
}