using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        
        private readonly MoveComponent _moveComponent;

        [Inject]
        public PickupEntity(MoveComponent moveComponent)
        {
            _moveComponent = moveComponent;
        }

        public void Update(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}