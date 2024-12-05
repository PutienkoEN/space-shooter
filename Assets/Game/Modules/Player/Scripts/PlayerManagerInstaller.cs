using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private Transform playerContainer;
        [SerializeField] private PlayerShipView playerShipPrefab;

        public override void Install(DiContainer container)
        {
            container
                .BindFactory<PlayerShipEntity, PlayerShipEntity.Factory>()
                .FromSubContainerResolve()
                .ByNewContextPrefab(playerShipPrefab)
                .UnderTransform(playerContainer);

            container
                .BindInterfacesAndSelfTo<PlayerManager>()
                .AsSingle();

            container
                .Bind<DebugPlayerManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<PlayerGameStartListener>()
                .AsSingle()
                .NonLazy();
        }
    }
}