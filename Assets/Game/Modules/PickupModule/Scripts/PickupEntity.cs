using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        
        private readonly MoveComponent _moveComponent;
        private readonly IPickupView _iPickupViewView;

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupViewView iPickupViewView)
        {
            _moveComponent = moveComponent;
            _iPickupViewView = iPickupViewView;

            _iPickupViewView.OnPickupTaken += HandlePickupTaken;
        }

        private void HandlePickupTaken()
        {
            
        }

        public void Update(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}