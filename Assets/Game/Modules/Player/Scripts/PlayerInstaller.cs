using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform worldContainer;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float speed;

        [SerializeField] private WeaponConfig _weaponConfig;

        public override void InstallBindings()
        {
            var player = Container
                .InstantiatePrefab(playerPrefab, spawnPosition.position, Quaternion.identity, worldContainer);

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
            
            Container.BindInterfacesAndSelfTo<WeaponCreator>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<WeaponController>()
                .AsSingle()
                .WithArguments(_weaponConfig, player);
        }
    }
}