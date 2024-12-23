using System.Collections.Generic;
using Zenject;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadManager : IInitializable
    {
        private readonly List<ISaveLoader> _saveLoaders;
        private readonly IGameContextRepository _gameContextRepository;

        public SaveLoadManager(List<ISaveLoader> saveLoaders, IGameContextRepository gameContextRepository)
        {
            _saveLoaders = saveLoaders;
            _gameContextRepository = gameContextRepository;
        }

        public void Initialize()
        {
            LoadGame();
        }

        public void SaveGame()
        {
            _saveLoaders.ForEach(saveLoader => saveLoader.SaveData());
            _gameContextRepository.Save();
        }

        private void LoadGame()
        {
            _gameContextRepository.Load();
            _saveLoaders.ForEach(saveLoader => saveLoader.LoadData());
        }

        public void ClearSave()
        {
            _gameContextRepository.Clear();
            LoadGame();
        }
    }
}