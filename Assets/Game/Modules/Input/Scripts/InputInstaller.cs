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
            var instantiatePrefabForComponent = Container
                .InstantiatePrefabForComponent<PlayerInput>(playerInput, transform);

            Container
                .BindInterfacesAndSelfTo<TouchInputHandler>()
                .AsSingle()
                .WithArguments(instantiatePrefabForComponent);

            Container
                .BindInterfacesAndSelfTo<TouchInputMovementHandler>()
                .AsSingle();
        }
    }
}