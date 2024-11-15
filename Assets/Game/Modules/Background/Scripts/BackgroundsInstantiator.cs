using System.ComponentModel;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.Background.Scripts
{
    public class BackgroundsInstantiator
    {

        public BackgroundsInstantiator(DiContainer container, BackgroundLayersConfig backgroundLayersConfig, Transform parent)
        {
            InstantiateBackgrounds(container, backgroundLayersConfig, parent);
        }

        private void InstantiateBackgrounds(
            DiContainer container, 
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
                GameObject backgroundObj = container.InstantiatePrefab(backgroundConfig.prefab, parent);
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
            }
        }

    }
}