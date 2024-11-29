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
                .BindFactory<EnemyView, Vector3, Quaternion, EnemyView, EnemyViewFactory>()
                .WithFactoryArguments(worldTransform)
                .AsSingle();

            container
                .BindFactory<Vector3, Quaternion, EnemyData, EnemyEntity, EnemyEntity.Factory>()
                .FromSubContainerResolve()
                .ByInstaller<EnemyInstaller>()
                .AsSingle();

            container
                .BindInterfacesAndSelfTo<EnemyManager>()
                .AsSingle();
        }
    }
}