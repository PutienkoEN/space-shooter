using System;
using Game.Modules.Level.Scripts;
using Game.Modules.LevelInterfaces.Scripts;

namespace SpaceShooter.Game.Level
{
    public class LevelManager
    {
        private readonly LevelConfigListData _levelConfigListData;

        private LevelData _levelData;

        public LevelManager(LevelConfigListData levelConfigListData)
        {
            _levelConfigListData = levelConfigListData;
        }

        public void LoadFirstLevel()
        {
            _levelData.currentLevel = 0;
        }

        public void LoadMaxLevel()
        {
            _levelData.currentLevel = _levelData.maxReachedLevel;
        }

        public void SetLevelData(LevelData levelData)
        {
            _levelData = levelData;
        }

        public LevelData GetLevelData()
        {
            return _levelData;
        }

        public void NextLevel()
        {
            _levelData.currentLevel = GetNextLevel();
        }

        public void FinishCurrentLevel()
        {
            var nextLevel = GetNextLevel();
            _levelData.maxReachedLevel = Math.Max(nextLevel, _levelData.maxReachedLevel);
        }

        private int GetNextLevel()
        {
            return Math.Min(_levelData.currentLevel + 1, _levelConfigListData.LevelConfigData.Count - 1);
        }

        public bool HasNextLevel()
        {
            return _levelData.currentLevel + 1 < _levelConfigListData.LevelConfigData.Count;
        }

        public bool HasPassedLevels()
        {
            return _levelData.maxReachedLevel > 0;
        }

        public ILevelConfigData GetLevelConfig()
        {
            return _levelConfigListData.LevelConfigData[_levelData.currentLevel];
        }
    }
}