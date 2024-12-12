using Game.Modules.BulletModule.Scripts;
using Game.Modules.Components;
using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.Components;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private SplineAnimate splineAnimate;
        [SerializeField] private WeaponConfig weaponConfig;

        [Inject] private EnemyData _enemyData;
        [Inject] private SplineContainer _splineContainer;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyEntity>()
                .AsSingle();

            Container
                .Bind<IEnemyView>()
                .To<EnemyView>()
                .FromComponentOnRoot()
                .AsSingle();

            Container
                .Bind<SplineMoveController>()
                .AsSingle()
                .WithArguments(splineAnimate, _splineContainer, _enemyData.Speed)
                .NonLazy();

            Container
                .Bind<HealthComponent>()
                .AsSingle()
                .WithArguments(_enemyData.Health);

            Container
                .Bind<CollisionDamageComponent>()
                .AsSingle()
                .WithArguments(_enemyData.CollisionDamage);

            Container
                .BindInterfacesAndSelfTo<EnemyDeathController>()
                .AsSingle()
                .NonLazy();

            Container.Bind<BoundsCheckComponent>().AsSingle();
            Container.BindInterfacesAndSelfTo<ColliderRectProvider>().AsSingle();
            
            Container.Bind<WeaponController>()
                .AsSingle()
                .WithArguments(weaponConfig, transform, (LayerMask)gameObject.layer);
        }
    }
}