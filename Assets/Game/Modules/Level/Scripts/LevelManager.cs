using Game.Modules.LevelInterfaces.Scripts;
using UnityEngine;

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

        public void FirstLevel()
        {
            _currentLevel = 0;
        }

        public bool NextLevel()
        {
            if (HasNextLevel())
            {
                _currentLevel++;
                return true;
            }

            Debug.LogWarning("Can't next level because there is no more levels in the list");
            return false;
        }

        public bool HasNextLevel()
        {
            return _currentLevel + 1 < _levelConfigListData.LevelConfigData.Count;
        }

        public ILevelData GetLevel()
        {
            return _levelConfigListData.LevelConfigData[_currentLevel];
        }
    }
}