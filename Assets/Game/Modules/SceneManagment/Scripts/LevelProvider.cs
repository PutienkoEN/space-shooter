using Game.Modules.LevelInterfaces.Scripts;
using Zenject;

namespace SpaceShooter.Game.SceneManagement
{
    public class LevelProvider : ILevelProvider
    {
        private readonly ILevelConfig _levelConfig;

        [Inject]
        public LevelProvider(ILevelConfig levelConfig)
        {
            _levelConfig = levelConfig;
        }

        public ILevelConfig GetLevelConfig()
        {
            return _levelConfig;
        }
    }
}