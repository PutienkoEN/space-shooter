using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;

namespace Zenject
{
    public class BackgroundGameContextInstaller : MonoInstaller
    {
        [SerializeField] private ConfigBackgrounds configBackgrounds;
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundController>().AsSingle().NonLazy();
            InstantiateBackgrounds(Container);
        }
        
        private void InstantiateBackgrounds(DiContainer container)
        {
            if (configBackgrounds == null)
            {
                Debug.LogError("No background configs found");
                return;
            }
            foreach (var backgroundConfig in configBackgrounds.configs)
            {
                GameObject obj = Container.InstantiatePrefab(backgroundConfig.prefab, parent);
                obj.transform.position = new Vector3(0, 0, backgroundConfig.zDistance);
                Material backgroundMaterial = backgroundConfig.material;
                obj.GetComponent<Renderer>().material = backgroundMaterial;
                
                container.Bind<BackgroundPresenter>().
                    AsTransient().
                    WithArguments(backgroundMaterial, backgroundConfig.speed).
                    NonLazy();
                // BackgroundPresenter presenter = new BackgroundPresenter(
                //     backgroundMaterial,
                //     backgroundConfig.speed);;
            }
        }
    }
}