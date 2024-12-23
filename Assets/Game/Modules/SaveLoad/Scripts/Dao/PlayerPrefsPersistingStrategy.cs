using UnityEngine;

namespace Game.Modules.SaveLoad
{
    public class PlayerPrefsPersistingStrategy : IPersistingStrategy
    {
        private const string GameContextKey = "GameContext";

        public void Save(string data)
        {
            PlayerPrefs.SetString(GameContextKey, data);
            PlayerPrefs.Save();
        }

        public bool TryLoad(out string data)
        {
            if (!PlayerPrefs.HasKey(GameContextKey))
            {
                Debug.LogError("Saved game context is not found.");
                data = default;
                return false;
            }

            var loadedData = PlayerPrefs.GetString(GameContextKey);
            data = loadedData;
            return true;
        }
    }
}