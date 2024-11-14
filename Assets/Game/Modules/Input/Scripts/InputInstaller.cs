using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceShooter.Input
{
    public class InputInstaller : MonoInstaller
    {
        [SerializeField] private PlayerInput playerInput;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerInput>()
                .FromInstance(playerInput)
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