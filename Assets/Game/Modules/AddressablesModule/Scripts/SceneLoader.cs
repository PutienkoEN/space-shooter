using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;

namespace Game.Modules.AddressablesModule.Scripts
{
    public class SceneLoader
    {
        private readonly Dictionary<string, AsyncOperationHandle> _handles = new();
        
        public async Task LoadScene(string sceneName, LoadSceneMode mode)
        {
            AsyncOperationHandle handle = Addressables.LoadSceneAsync(sceneName, mode);
            await handle.Task;
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _handles[sceneName] = handle;
            }
            else
            {
                Debug.LogError($"Failed to load scene with key: {sceneName}. No location found.");
            }
        }

        public void Release(string name)
        {
            if (_handles.TryGetValue(name, out var handle))
            {
                Addressables.Release(handle);
                _handles.Remove(name);
            }
        }

        public void ReleaseAll()
        {
            foreach (var t in _handles)
            {
                Addressables.Release(t);
            }
            _handles.Clear();
        }

        public bool Contains(string name)
        {
           return _handles.ContainsKey(name);
        }
    }
}