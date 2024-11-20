using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace SpaceShooter.Game.Input
{
    public class InputInstaller : MonoBehaviour, IGameModuleInstaller
    {
        [SerializeField] private PlayerInput playerInput;

        public void Install(DiContainer container)
        {
            container
                .Bind<PlayerInput>()
                .FromInstance(playerInput)
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<TouchInputHandler>()
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<TouchInputMovementHandler>()
                .AsSingle();
        }
    }
}