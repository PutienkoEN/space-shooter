using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule
{
    public sealed class BulletModuleInstaller : GameModuleInstaller
    {
        [SerializeField] private BulletView bulletViewPrefab;
        [SerializeField] private Transform bulletContainer;

        public override void Install(DiContainer container)
        {
            container
                .Bind<BulletViewFactory>()
                .AsSingle();

            container
                .Bind<BulletEntityFactory>()
                .AsSingle();

            container
                .Bind<BulletSpawner>()
                .AsSingle()
                .NonLazy();

            container
                .BindInterfacesAndSelfTo<BulletManager>()
                .AsSingle()
                .NonLazy();
        }
    }
}