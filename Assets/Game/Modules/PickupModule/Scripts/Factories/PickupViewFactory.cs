using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public class PickupViewFactory
    {
        private readonly DiContainer _container;
        private readonly Transform _parent;

        [Inject]
        public PickupViewFactory(DiContainer container, Transform parent)
        {
            _container = container;
            _parent = parent;
        }

        public PickupView Create(PickupCreateData data)
        { 
            var subContainer = _container.CreateSubContainer();

            subContainer.Bind<PickupCreateData>().FromInstance(data).AsSingle();

            return subContainer.InstantiatePrefabForComponent<PickupView>(
                data.PickupPrefab,
                data.SpawnPosition,
                data.SpawnRotation,
                _parent);
        }
    }
}