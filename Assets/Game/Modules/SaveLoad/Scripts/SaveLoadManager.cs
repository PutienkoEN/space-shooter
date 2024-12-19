using System.Collections.Generic;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadManager
    {
        private readonly List<ISaveLoader> _saveLoaders;
        private readonly IGameContextRepository _gameContextRepository;

        public SaveLoadManager(List<ISaveLoader> saveLoaders, IGameContextRepository gameContextRepository)
        {
            _saveLoaders = saveLoaders;
            _gameContextRepository = gameContextRepository;
        }

        public void SaveGame()
        {
            _saveLoaders.ForEach(saveLoader => saveLoader.SaveData());
            _gameContextRepository.Save();
        }

        public void LoadGame()
        {
            _gameContextRepository.Load();
            _saveLoaders.ForEach(saveLoader => saveLoader.LoadData());
        }
    }
}