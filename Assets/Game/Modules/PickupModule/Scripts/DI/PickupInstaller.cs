using SpaceShooter.Game.Components;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public class PickupInstaller : MonoInstaller
    {
        
        [Inject] private float _speed;
        
        public override void InstallBindings()
        {
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
                .WithArguments(transform, _speed)
                .NonLazy();
            
        }
    }
}