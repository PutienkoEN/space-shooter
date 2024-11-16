using System.Collections.Generic;
using Game.Modules.Background.Scripts.Data;
using SpaceShooter.Background;
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

        public IReadOnlyList<IBackgroundPresenter> GetPresentersList()
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

            foreach (var backgroundConfig in backgroundLayersConfig.GetBackgroundLayersData())
            {
                if (backgroundConfig.Prefab == null)
                {
                    Debug.LogError("Background prefab is null");
                    return;
                }
                var position = new Vector3(0, 0, backgroundConfig.ZDistance);
                GameObject backgroundObj = Object.Instantiate(
                    backgroundConfig.Prefab, 
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
                    rendererComponent.material = backgroundConfig.Material;
                }
                else
                {
                    Debug.LogError("Failed to get Renderer component on background prefab.");
                }
                
                IBackgroundPresenter presenter = new BackgroundPresenter(backgroundConfig.Material, backgroundConfig.Speed);
                _backgroundPresenters.Add(presenter);
            }
        }
    }
}
        