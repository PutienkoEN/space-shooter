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
            return new LevelData()
            {
                MaxLevel = 0
            };
        }

        protected override void HandleDataLoad(LevelData savedData)
        {
            Debug.Log("Loading save data");
        }
    }

    public class LevelData
    {
        public int MaxLevel { get; set; }
    }
}