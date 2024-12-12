using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyViewFactory
    {
        private readonly DiContainer _container;
        private readonly Transform _parent;

        [Inject]
        public EnemyViewFactory(DiContainer container, Transform parent)
        {
            _container = container;
            _parent = parent;
        }

        public EnemyView Create(EnemyCreateData enemyCreateData)
        {
            var subContainer = _container.CreateSubContainer();

            subContainer.Bind<EnemyData>().FromInstance(enemyCreateData.EnemyData).AsSingle();
            subContainer.Bind<SplineContainer>().FromInstance(enemyCreateData.SplineContainer).AsSingle();

            return subContainer.InstantiatePrefabForComponent<EnemyView>(
                enemyCreateData.EnemyData.EnemyPrefab,
                enemyCreateData.SpawnPosition,
                enemyCreateData.SpawnRotation,
                _parent);
        }
    }
}