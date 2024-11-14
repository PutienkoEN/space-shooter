using UnityEngine.InputSystem;
using Zenject;

namespace SpaceShooter.Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<PlayerInput>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TouchInputHandler>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TouchInputMovementHandler>()
                .AsSingle();
        }
    }
}