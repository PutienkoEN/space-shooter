using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.Components;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private Transform worldContainer;
        [SerializeField] private Transform spawnPosition;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float speed;

        [SerializeField] private WeaponDataConfig weaponDataConfig;

        public override void InstallBindings()
        {
            GameObject player = Container
                .InstantiatePrefab(playerPrefab, spawnPosition.position, Quaternion.identity, worldContainer);
            
            Container.Bind<GameObject>()
                .WithId("Player")
                .FromInstance(player)
                .AsSingle();

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