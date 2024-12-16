using Game.Modules.LevelInterfaces.Scripts;

namespace SpaceShooter.Game.Level
{
    public class LevelManager
    {
        private readonly LevelConfigListData _levelConfigListData;
        private int _currentLevel;

        public LevelManager(LevelConfigListData levelConfigListData)
        {
            _levelConfigListData = levelConfigListData;
        }

        public void NextLevel()
        {
            _currentLevel++;
        }

        public ILevelData GetLevel()
        {
            return _levelConfigListData.LevelConfigData[_currentLevel];
        }
    }
}