using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipInstaller : MonoInstaller
    {
        [SerializeField] private float speed;
        [SerializeField] private float health;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerShipEntity>()
                .AsSingle();

            Container
                .Bind<PlayerShipView>()
                .FromComponentOnRoot()
                .AsSingle();

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(transform, speed);

            var component = GetComponentInChildren<Collider>();
            Container
                .Bind<ColliderComponent>()
                .AsSingle()
                .WithArguments(component);

            Container
                .Bind<HealthComponent>()
                .AsSingle()
                .WithArguments(health);

            Container
                .BindInterfacesAndSelfTo<PlayerHealthController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();
        }
    }
}