using System;
using Game.Modules.Level;
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

        public void SetLevelData(LevelData levelData)
        {
            _levelData = levelData;
        }

        public LevelData GetLevelData()
        {
            return _levelData;
        }

        public void LoadFirstLevel()
        {
            if (GetLevelsCount() == 0)
            {
                throw new ArgumentException("There is no available levels!");
            }

            _levelData.currentLevel = 0;
        }

        public void LoadMaxLevel()
        {
            _levelData.currentLevel = Math.Min(_levelData.maxReachedLevel, GetLevelsCount());
        }

        public bool NextLevel()
        {
            if (!TryGetNextLevel(out var nextLevel))
            {
                return false;
            }

            _levelData.currentLevel = nextLevel;
            return true;
        }

        public bool HasNextLevel()
        {
            return TryGetNextLevel(out _);
        }

        public void FinishCurrentLevel()
        {
            var maxLevelReached = GetMaxLevelReached();
            _levelData.maxReachedLevel = Math.Max(maxLevelReached, _levelData.maxReachedLevel);
        }

        private int GetMaxLevelReached()
        {
            if (TryGetNextLevel(out var nextLevel))
            {
                return nextLevel;
            }

            return _levelData.currentLevel;
        }

        private bool TryGetNextLevel(out int nextLevel)
        {
            var potentiallyNextLevel = _levelData.currentLevel + 1;
            if (potentiallyNextLevel >= GetLevelsCount())
            {
                nextLevel = default;
                return false;
            }

            nextLevel = potentiallyNextLevel;
            return true;
        }

        private int GetLevelsCount()
        {
            return _levelConfigListData.LevelConfigData.Count;
        }

        public bool HasFinishedLevels()
        {
            return _levelData.maxReachedLevel > 0;
        }

        public ILevelConfigData GetLevelConfig()
        {
            return _levelConfigListData.LevelConfigData[_levelData.currentLevel];
        }
    }
}