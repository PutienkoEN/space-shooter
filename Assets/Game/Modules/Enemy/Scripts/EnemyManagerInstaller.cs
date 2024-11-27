using Game.Modules.EnemyGroup.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class EnemyManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private Transform worldTransform;
        [SerializeField] private LevelConfiguration levelConfiguration;

        public override void Install(DiContainer container)
        {
            container
                .BindFactory<EnemyView, Vector3, Quaternion, EnemyView, EnemyViewFactory>()
                .WithFactoryArguments(worldTransform)
                .AsSingle();

            container
                .BindFactory<Vector3, Quaternion, EnemyData, EnemyEntity, EnemyEntity.Factory>()
                .FromSubContainerResolve()
                .ByInstaller<EnemyInstaller>()
                .AsSingle();

            container
                .Bind<LevelData>()
                .FromInstance(levelConfiguration.GetData())
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();

            container
                .Bind<LevelManager>()
                .AsSingle();

            container
                .Bind<DebugEnemyManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}