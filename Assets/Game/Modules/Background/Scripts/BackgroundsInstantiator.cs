using System.Collections.Generic;
using System.Linq;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.Background.Scripts
{
    public sealed class BackgroundsInstantiator
    {
        private readonly List<IBackgroundPresenter> _backgroundPresenters = new();
        
        public BackgroundsInstantiator(
            BackgroundDataConfig backgroundDataConfig,
            Transform parent)
        {
            InstantiateBackgrounds(backgroundDataConfig, parent);
        }

        public IReadOnlyList<IBackgroundPresenter> GetPresentersList()
        {
            return _backgroundPresenters;
        }

        private void InstantiateBackgrounds(
            BackgroundDataConfig backgroundDataConfig,
            Transform parent)
        {
            if (backgroundDataConfig == null || parent == null)
            {
                Debug.LogError("Check if config and parent for backgrounds are added");
                return;
            }

            foreach (var backgroundConfig in backgroundDataConfig.configs)
            {
                if (backgroundConfig.prefab == null)
                {
                    Debug.LogError("Background prefab is null");
                    return;
                }
                var position = new Vector3(0, 0, backgroundConfig.zDistance);
                GameObject backgroundObj = Object.Instantiate(
                    backgroundConfig.prefab, 
                    position,
                    Quaternion.identity,
                    parent);
                
                if (backgroundObj == null)
                {
                    Debug.LogError("Failed to instantiate background.");
                    return;
                }

                var rendererComponent = backgroundObj.GetComponentInChildren<Renderer>();
                if(rendererComponent != null)
                {
                    rendererComponent.material = backgroundConfig.material;
                }
                else
                {
                    Debug.LogError("Failed to get Renderer component on background prefab.");
                }
                
                IBackgroundPresenter presenter = new BackgroundPresenter(backgroundConfig.material, backgroundConfig.speed);
                _backgroundPresenters.Add(presenter);
            }
        }
    }
}
        