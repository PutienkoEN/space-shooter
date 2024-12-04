using Game.Modules.BulletModule.Scripts;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyInstaller : Installer<EnemyInstaller>
    {
        private readonly EnemyViewFactory _enemyViewFactory;
        private readonly EnemyCreateData _enemyCreateData;

        [Inject]
        public EnemyInstaller(
            EnemyCreateData enemyCreateData,
            EnemyViewFactory enemyViewFactory)
        {
            _enemyCreateData = enemyCreateData;
            _enemyViewFactory = enemyViewFactory;
        }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyEntity>()
                .AsSingle();

            var enemyData = _enemyCreateData.EnemyData;

            var enemyView = _enemyViewFactory.Create(
                enemyData.EnemyPrefab,
                _enemyCreateData.SpawnPosition,
                _enemyCreateData.SpawnRotation);

            Container
                .BindInterfacesTo(enemyView.GetType())
                .FromInstance(enemyView)
                .AsSingle();

            Container
                .Bind<SplineMoveController>()
                .AsSingle()
                .WithArguments(enemyView.GetSplineAnimate(), _enemyCreateData.SplineContainer, enemyData.Speed)
                .NonLazy();

            Container
                .Bind<HealthComponent>()
                .AsSingle()
                .WithArguments(enemyData.Health);

            Container
                .BindInterfacesAndSelfTo<EnemyDeathController>()
                .AsSingle()
                .NonLazy();


            Container.Bind<BoundsCheckComponent>().AsSingle();
            Container.BindInterfacesAndSelfTo<ColliderRectProvider>().AsSingle();
        }
    }
}