using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        private readonly EnemyViewFactory _enemyViewFactory;

        private readonly EnemyData _enemyData;
        private readonly Vector3 _position;
        private readonly Quaternion _rotation;

        [Inject]
        public EnemyInstaller(
            EnemyData enemyData,
            Vector3 position,
            Quaternion rotation,
            EnemyViewFactory enemyViewFactory)
        {
            _enemyData = enemyData;
            _position = position;
            _rotation = rotation;
            _enemyViewFactory = enemyViewFactory;
        }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyEntity>()
                .AsSingle();

            var enemyView = _enemyViewFactory.Create(_enemyData.EnemyPrefab, _position, _rotation);
            Container
                .BindInterfacesTo(enemyView.GetType())
                .FromInstance(enemyView)
                .AsSingle();
            

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(enemyView.transform, _enemyData.Speed);

            Container
                .Bind<HealthComponent>()
                .AsSingle()
                .WithArguments(_enemyData.Health);

            Container
                .BindInterfacesAndSelfTo<EnemyDeathController>()
                .AsSingle()
                .NonLazy();
            
            Container.Bind<BoundsCheckComponent>().AsSingle();
            Container.BindInterfacesAndSelfTo<ColliderRectProvider>().AsSingle();
        }
    }
}