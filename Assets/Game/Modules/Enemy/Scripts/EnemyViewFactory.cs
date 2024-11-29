using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyViewFactory : PlaceholderFactory<EnemyView, Vector3, Quaternion, EnemyView>
    {
        private readonly DiContainer _container;
        private readonly Transform _parent;

        [Inject]
        public EnemyViewFactory(DiContainer container, Transform parent)
        {
            _container = container;
            _parent = parent;
        }

        public override EnemyView Create(EnemyView prefab, Vector3 position, Quaternion rotation)
        {
            return _container.InstantiatePrefabForComponent<EnemyView>(prefab, position, rotation, _parent);
        }
    }
}