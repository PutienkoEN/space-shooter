using UnityEngine.InputSystem;
using Zenject;

namespace Input
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
                .AsSingle()
                .NonLazy();
        }
    }
}