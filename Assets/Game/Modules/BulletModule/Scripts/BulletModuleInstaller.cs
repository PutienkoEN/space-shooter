using System.ComponentModel;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletModuleInstaller : GameModuleInstaller
    {
        [SerializeField] private BulletView bulletViewPrefab;
        [SerializeField] private Transform bulletContainer;

        public override void Install(DiContainer container)
        {
            container.BindFactory<float, int, BulletEntity, BulletEntity.Factory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab<BulletInstaller>(bulletViewPrefab)
                .UnderTransform(bulletContainer);
            
            container.Bind<IFactory<float, int, BulletEntity>>()
                .To<BulletEntity.Factory>()
                .FromResolve();

            container.Bind<BulletSpawner>().AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<BulletController>().AsSingle().NonLazy();
            container.Bind<CollisionConditions>().AsSingle().NonLazy();
            container.BindInterfacesAndSelfTo<CollisionProcessor>().AsSingle().NonLazy();
        }
    }
}