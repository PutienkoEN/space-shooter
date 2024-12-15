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
                .Bind<IPickupConfig>()
                .FromInstance(pickupConfig)
                .AsSingle();
            
            Container
                .BindInterfacesAndSelfTo<PickupEntity>()
                .AsSingle();

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(transform, speed)
                .NonLazy();
        }
    }
}