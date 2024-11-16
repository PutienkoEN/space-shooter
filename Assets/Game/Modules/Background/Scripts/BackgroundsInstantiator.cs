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

            foreach (var backgroundData in backgroundLayersConfig.GetBackgroundLayersData())
            {
                if (backgroundData.Prefab == null)
                {
                    Debug.LogError("Background prefab is null");
                    return;
                }
                var position = new Vector3(0, 0, backgroundData.ZDistance);
                GameObject backgroundObj = Object.Instantiate(
                    backgroundData.Prefab, 
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
                    rendererComponent.material = backgroundData.Material;
                }
                else
                {
                    Debug.LogError("Failed to get Renderer component on background prefab.");
                }
                
                IBackgroundPresenter presenter = new BackgroundPresenter(backgroundData.Material, backgroundData.Speed);
                _backgroundPresenters.Add(presenter);
            }
        }
    }
}
        