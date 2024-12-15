using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public class PickupManagerInstaller: GameModuleInstaller
    {
        [SerializeField] private Transform worldTransform;

        public override void Install(DiContainer container)
        {
            container
                .Bind<PickupViewFactory>()
                .AsSingle()
                .WithArguments(worldTransform);

            container
                .Bind<PickupEntityFactory>()
                .AsSingle();
            
            container
                .BindInterfacesAndSelfTo<PickupManager>()
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<WeaponPickupStrategy>()
                .AsSingle();
            
            container
                .Bind<PickupItemProcessor>()
                .AsSingle()
                .NonLazy();
        }
    }
}