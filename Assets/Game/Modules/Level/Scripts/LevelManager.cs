using Game.Modules.LevelInterfaces.Scripts;

namespace SpaceShooter.Game.Level
{
    public class LevelManager
    {
        private LevelEventManager _levelEventManager;
        private ILevelProvider _levelProvider;

        public void StartLevel()
        {
            var levelConfig = (LevelConfig)_levelProvider.GetLevelConfig();
            _levelEventManager.StartLevel(levelConfig.GetData());
        }

        public void StartLevel(LevelConfig levelConfig)
        {
            _levelEventManager.StartLevel(levelConfig.GetData());
        }
    }
}