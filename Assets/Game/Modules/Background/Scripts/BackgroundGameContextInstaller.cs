using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;

namespace Zenject
{
    public sealed class BackgroundGameContextInstaller : MonoInstaller
    {
        [SerializeField] private ConfigBackgrounds configBackgrounds;
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            InstantiateBackgrounds(Container);
            BindBackgroundPresenters(Container);
            Container.BindInterfacesAndSelfTo<BackgroundController>().AsSingle().NonLazy();
        }
        
        private void InstantiateBackgrounds(DiContainer container)
        {
            if (configBackgrounds == null || parent == null)
            {
                Debug.LogError("Check if config and parent for backgrounds are added");
                return;
            }
            foreach (var backgroundConfig in configBackgrounds.configs)
            {
                GameObject backgroundObj = Container.InstantiatePrefab(backgroundConfig.prefab, parent);
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

        private void BindBackgroundPresenters(DiContainer container)
        {
            foreach (var backgroundConfig in configBackgrounds.configs)
            {
                container.BindInterfacesAndSelfTo<BackgroundPresenter>().
                    AsTransient().
                    WithArguments(backgroundConfig.material, backgroundConfig.speed).
                    NonLazy();
            }
        }
    }
}