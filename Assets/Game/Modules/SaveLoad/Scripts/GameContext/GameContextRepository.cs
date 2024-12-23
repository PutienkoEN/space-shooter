using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game.Modules.SaveLoad
{
    public class GameContextRepository : IGameContextRepository, IGameContext
    {
        private readonly IPersistingStrategy _persistingStrategy;

        private Dictionary<string, string> _context = new();

        public GameContextRepository(IPersistingStrategy persistingStrategy)
        {
            _persistingStrategy = persistingStrategy;
        }

        public void SetData<T>(T value)
        {
            var serializedData = JsonConvert.SerializeObject(value);
            _context[typeof(T).Name] = serializedData;
        }

        public bool TryGetData<T>(out T value)
        {
            if (_context.TryGetValue(typeof(T).Name, out var serializedData))
            {
                value = JsonConvert.DeserializeObject<T>(serializedData);
                return true;
            }

            value = default;
            return false;
        }

        public void Save()
        {
            SaveAsJson(_context);
        }

        public void Load()
        {
            if (!_persistingStrategy.TryLoad(out var loadedContext))
            {
                Clear();
                return;
            }

            _context = JsonConvert.DeserializeObject<Dictionary<string, string>>(loadedContext);
        }

        public void Clear()
        {
            var emptyContext = new Dictionary<string, string>();
            SaveAsJson(emptyContext);
        }

        private void SaveAsJson(Dictionary<string, string> context)
        {
            var serializedContext = JsonConvert.SerializeObject(context);
            _persistingStrategy.Save(serializedContext);
        }
    }
}