using Game.Modules.LevelInterfaces.Scripts;
using Zenject;

namespace Game.Modules.Manager.Scripts
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