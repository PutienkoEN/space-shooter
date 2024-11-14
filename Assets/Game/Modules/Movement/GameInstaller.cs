using SpaceShooter.Input;
using SpaceShooter.Movement;
using UnityEngine;
using Zenject;

namespace Input
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float speed;

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(playerPrefab.transform, speed);

            var component = playerPrefab.GetComponent<Collider>();
            Container
                .Bind<ColliderComponent>()
                .AsSingle()
                .WithArguments(component);

            Container
                .Bind<WorldUtility>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }
    }
}