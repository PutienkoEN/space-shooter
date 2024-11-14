using SpaceShooter.Movement;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float speed;

        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefab(playerPrefab, transform);

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(player.transform, speed);

            var component = player.GetComponentInChildren<Collider>();
            Container
                .Bind<ColliderComponent>()
                .AsSingle()
                .WithArguments(component);

            Container
                .BindInterfacesAndSelfTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }
    }
}