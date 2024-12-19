using System.Collections.Generic;
using UnityEngine;

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
            var serializedData = JsonUtility.ToJson(value);
            _context[typeof(T).Name] = serializedData;
        }

        public bool TryGetData<T>(out T value)
        {
            if (_context.TryGetValue(typeof(T).Name, out var serializedData))
            {
                value = JsonUtility.FromJson<T>(serializedData);
                return true;
            }

            value = default;
            return false;
        }

        public void Save()
        {
            var serializedContext = JsonUtility.ToJson(_context);
            _persistingStrategy.Save(serializedContext);
        }

        public void Load()
        {
            if (!_persistingStrategy.TryLoad(out var loadedContext))
            {
                return;
            }

            _context = JsonUtility.FromJson<Dictionary<string, string>>(loadedContext);
        }
    }
}