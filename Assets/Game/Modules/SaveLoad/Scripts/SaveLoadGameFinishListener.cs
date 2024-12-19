using SpaceShooter.Game.LifeCycle.Common;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadGameFinishListener : IGameFinishListener
    {
        private readonly SaveLoadManager _saveLoadManager;

        public SaveLoadGameFinishListener(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }

        public void OnGameFinish()
        {
            _saveLoadManager.SaveGame();
        }
    }
}