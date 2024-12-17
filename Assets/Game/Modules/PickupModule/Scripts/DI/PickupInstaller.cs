using Game.Modules.BulletModule.Scripts;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public class PickupInstaller : MonoInstaller
    {

        [SerializeField] private float speed;
        [SerializeField] private PickupConfig pickupConfig;
        
        public override void InstallBindings()
        {
            Container
                .Bind<IPickupConfigData>()
                .FromInstance(pickupConfig.GetPickupData())
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PickupEntity>()
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PickupView>()
                .FromComponentOnRoot()
                .AsSingle();

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(transform, speed)
                .NonLazy();

            Container.BindInterfacesAndSelfTo<ColliderRectProvider>().AsSingle();
            
            Container
                .Bind<BoundsCheckComponent>()
                .AsSingle()
                .NonLazy();
        }
    }
}