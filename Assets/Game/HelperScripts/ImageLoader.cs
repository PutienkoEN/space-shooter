using System;
using System.Threading.Tasks;
using Game.Modules.AddressablesModule.Scripts;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game.HelperScripts
{
    public class ImageLoader : MonoBehaviour
    {
        public Image imageComponent;
        
        private AssetLoader<Sprite> _spriteLoader;
        private SceneLoader _sceneLoader;
        

        private void Awake()
        {
            _spriteLoader = new AssetLoader<Sprite>();
            _sceneLoader = new SceneLoader();
        }

        [Button]
        public async Task LoadImage(string assetName)
        {
            imageComponent.sprite = await _spriteLoader.LoadAsset(assetName);
        }

        [Button]
        public void UnloadImage(string assetName)
        {
            Debug.Log("trying to release");
            if (_spriteLoader.Contains(assetName))
            {
                Debug.Log("found to release");
                imageComponent.sprite = null;
                _spriteLoader.Release(assetName);
            }
        }
        
        [Button]
        public async Task LoadScene(string sceneName)
        {
            await _sceneLoader.LoadScene(sceneName, LoadSceneMode.Single);
        }

        [Button]
        public void UnloadScene(string sceneName)
        {
            Debug.Log("trying to release");
            if (_sceneLoader.Contains(sceneName))
            {
                Debug.Log("found to release");
                _sceneLoader.Release(sceneName);
            }
        }
    }
}