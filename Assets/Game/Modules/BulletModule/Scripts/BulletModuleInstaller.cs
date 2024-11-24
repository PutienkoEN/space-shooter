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
            Container.BindFactory<float, BulletEntity, BulletEntity.Factory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab<BulletInstaller>(bulletViewPrefab);

            Container.Bind<BulletSpawner>().AsSingle().NonLazy();
            Container.Bind<OutOfBoundsController>().AsSingle().NonLazy();
            
            Container.BindInterfacesAndSelfTo<BulletController>().AsSingle().NonLazy();

        }
    }
}