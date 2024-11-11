using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game.Modules.AddressablesModule.Scripts
{
    public sealed class AssetLoader<T>
    {
        private readonly Dictionary<string, AsyncOperationHandle<T>> _handles = new();
        public async Task<T> LoadAsset(string assetName)
        {
            if (_handles.TryGetValue(assetName, out var handle))
            {
                return handle.Result;
            }

            AsyncOperationHandle<T> newHandle = Addressables.LoadAssetAsync<T>(assetName);
            await newHandle.Task;

            if (newHandle.Status == AsyncOperationStatus.Succeeded)
            {
                _handles[assetName] = newHandle;
                return newHandle.Result;
            }

            Debug.LogError($"Failed to load asset with key: {assetName}. No location found.");
            return default;
        }

        public void Release(string assetName)
        {
            if (_handles.TryGetValue(assetName, out var handle))
            {
                Addressables.Release(handle);
                _handles.Remove(assetName);
            }
        }

        public void ReleaseAll()
        {
            foreach (var handle in _handles.Values)
            {
                Addressables.Release(handle);
            }
            _handles.Clear();
        }

        public bool Contains(string assetName) => _handles.ContainsKey(assetName);
    }
}