using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private Transform worldTransform;

        public override void Install(DiContainer container)
        {
            container
                .Bind<EnemyViewFactory>()
                .AsSingle()
                .WithArguments(worldTransform);

            container
                .Bind<EnemyEntityFactory>()
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();
        }
    }
}