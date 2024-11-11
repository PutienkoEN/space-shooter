using UnityEngine;
using Zenject;

namespace Input
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private Character player;

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TouchInputPlayerMovementController>()
                .AsSingle()
                .WithArguments(player)
                .NonLazy();

            Container
                .Bind<WorldUtility>()
                .AsSingle();
        }
    }
}