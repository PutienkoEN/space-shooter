using Game.Modules.Level.Scripts;
using Game.Modules.SaveLoad;
using SpaceShooter.Game.Level;
using UnityEngine;

namespace Game.Modules.Level
{
    public class LevelSaveLoader : AbstractSaveLoader<LevelData>
    {
        private readonly LevelManager _levelManager;

        public LevelSaveLoader(LevelManager levelManager, IGameContext gameContext) : base(gameContext)
        {
            _levelManager = levelManager;
        }

        protected override LevelData GetDataToSave()
        {
            return _levelManager.GetLevelData();
        }

        protected override void HandleDataLoad(LevelData levelData)
        {
            _levelManager.SetLevelData(levelData);
        }

        protected override void HandleDataLoadMissing()
        {
            Debug.LogWarning("There is no saved level data, creating new one.");
            _levelManager.SetLevelData(new LevelData());
        }
    }
}