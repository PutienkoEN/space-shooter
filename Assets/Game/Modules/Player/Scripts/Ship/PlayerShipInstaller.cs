using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipInstaller : MonoInstaller
    {
        [SerializeField] private float speed;
        [SerializeField] private int health;
        
        [SerializeField] private WeaponConfig weaponConfig;

        public override void InstallBindings()
        {
            Container
                .Bind<PlayerShipEntity>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<PlayerShipView>()
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
                .Bind<PlayerDeathController>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<PlayerMoveController>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<WeaponController>()
                .AsSingle()
                .WithArguments(weaponConfig, transform, (LayerMask)gameObject.layer);
        }
    }
}