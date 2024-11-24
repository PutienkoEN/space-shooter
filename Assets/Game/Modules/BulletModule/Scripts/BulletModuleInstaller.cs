using Game.Modules.ShootingModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletModuleInstaller : MonoInstaller
    {
        [SerializeField] private BulletView bulletViewPrefab;
        [SerializeField] private Transform bulletContainer;
        [SerializeField] private int initialPoolSize = 10;
        
        public override void InstallBindings()
        {

            // Container.BindMemoryPool<BulletView, BulletMemoryPool>()
            //     .WithInitialSize(initialPoolSize) 
            //     .FromComponentInNewPrefab(bulletViewPrefab)
            //     .UnderTransform(bulletContainer)
            //     .NonLazy();

            // Container.Bind<IMemoryPool<BulletView>>()
            //     .To<BulletMemoryPool>()
            //     .FromResolve();
            
            // Container.Bind<BulletPoolController>()
            //     .FromComponentInHierarchy()
            //     .AsSingle()
            //     .NonLazy();
            
            Container.BindFactory<float, BulletEntity, BulletEntity.Factory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab<BulletInstaller>(bulletViewPrefab);

            Container.Bind<BulletSpawner>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BulletController>().AsSingle().NonLazy();

        }
    }
}