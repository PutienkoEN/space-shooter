using System.Collections.Generic;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.Background.Scripts
{
    public sealed class BackgroundsInstantiator
    {
        private readonly List<IBackgroundPresenter> _backgroundPresenters = new();
        public BackgroundsInstantiator(
            BackgroundLayersConfig backgroundLayersConfig,
            Transform parent)
        {
            InstantiateBackgrounds(backgroundLayersConfig, parent);
        }

        public List<IBackgroundPresenter> GetPresentersList()
        {
            return _backgroundPresenters;
        }

        private void InstantiateBackgrounds(
            BackgroundLayersConfig backgroundLayersConfig,
            Transform parent)
        {
            if (backgroundLayersConfig == null || parent == null)
            {
                Debug.LogError("Check if config and parent for backgrounds are added");
                return;
            }

            foreach (var backgroundConfig in backgroundLayersConfig.configs)
            {
                GameObject backgroundObj = Object.Instantiate(backgroundConfig.prefab, parent);
                if (backgroundObj == null)
                {
                    Debug.LogError("Failed to instantiate background.");
                    return;
                }

                backgroundObj.transform.position = new Vector3(0, 0, backgroundConfig.zDistance);
                if (backgroundObj.TryGetComponent(out Renderer rendererComponent))
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
        