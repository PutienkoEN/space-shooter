using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipInstaller : MonoInstaller
    {
        [SerializeField] private WeaponConfig weaponConfig;
        [SerializeField] private float speed;

        public override void InstallBindings()
        {
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
                .Bind<PlayerShipView>()
                .FromComponentOnRoot()
                .AsSingle();

            Container
                .Bind<PlayerShipEntity>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerMovementController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<WeaponCreator>()
                .AsSingle();

            Container.BindInterfacesAndSelfTo<WeaponController>()
                .AsSingle()
                .WithArguments(weaponConfig, gameObject);
        }
    }
}