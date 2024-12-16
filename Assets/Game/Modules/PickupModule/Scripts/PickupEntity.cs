using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        private readonly IPickupConfig _config;
        private readonly MoveComponent _moveComponent;

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupConfig config)
        {
            _moveComponent = moveComponent;
            _config = config;
            
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}