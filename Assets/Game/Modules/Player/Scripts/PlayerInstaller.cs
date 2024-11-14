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
            var instantiatePrefab = Container.InstantiatePrefab(playerPrefab, transform);

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
                .BindInterfacesAndSelfTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();
        }
    }
}