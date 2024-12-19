using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.SaveLoad
{
    public class DebugSaveLoadManager : MonoBehaviour
    {
        private SaveLoadManager _saveLoadManager;

        [Inject]
        public void Construct(SaveLoadManager saveLoadManager)
        {
            _saveLoadManager = saveLoadManager;
        }

        [Button]
        public void ResetSave()
        {
            _saveLoadManager.ClearSave();
        }

        [Button]
        public void LoadSave()
        {
            _saveLoadManager.Initialize();
        }
    }
}