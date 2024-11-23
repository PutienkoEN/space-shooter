using Game.Modules.ShootingModule.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletModuleInstaller : MonoInstaller
    {
        [SerializeField] private BulletComponent bulletComponentPrefab;
        [SerializeField] private BulletView bulletViewPrefab;
        [SerializeField] private Transform bulletContainer;
        [SerializeField] private int initialPoolSize = 10;
        
        public override void InstallBindings()
        {

            // Container.BindMemoryPool<BulletComponent, BulletMemoryPool>()
            //     .WithInitialSize(initialPoolSize) 
            //     .FromComponentInNewPrefab(bulletComponentPrefab)
            //     .UnderTransform(bulletContainer)
            //     .NonLazy();

            // Container.Bind<IMemoryPool<BulletComponent>>()
            //     .To<BulletMemoryPool>()
            //     .FromResolve();
            
            // Container.Bind<BulletPoolController>()
            //     .FromComponentInHierarchy()
            //     .AsSingle()
            //     .NonLazy();

            Container.BindFactory<BulletComponent, BulletComponent.Factory>()
                .FromComponentInNewPrefab(bulletComponentPrefab)
                .UnderTransform(bulletContainer);

            Container.BindFactory<Bullet, Bullet.Factory>();
            
            Container.BindFactory<NewBullet, NewBullet.Factory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(bulletViewPrefab);
            

            Container.Bind<BulletSpawner>().AsSingle().NonLazy();

        }
    }
}