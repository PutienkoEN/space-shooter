namespace Game.Modules.SaveLoad
{
    public abstract class AbstractSaveLoader<TData> : ISaveLoader
    {
        private readonly IGameContext _gameContext;

        protected AbstractSaveLoader(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void SaveData()
        {
            var dataToSave = GetDataToSave();
            _gameContext.SetData(dataToSave);
        }

        public void LoadData()
        {
            if (_gameContext.TryGetData(out TData savedData))
            {
                HandleDataLoad(savedData);
            }
            else
            {
                HandleDataLoadMissing();
            }
        }

        protected abstract TData GetDataToSave();
        protected abstract void HandleDataLoad(TData savedData);

        protected virtual void HandleDataLoadMissing()
        {
        }
    }
}