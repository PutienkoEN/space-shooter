using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        private readonly IPickupConfig _config;
        private readonly IPickupView _pickupView;
        private readonly MoveComponent _moveComponent;
        private readonly PickupItemProcessor _pickupItemProcessor;
        

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupConfig config,
            IPickupView pickupView, 
            PickupItemProcessor pickupItemProcessor)
        {
            _moveComponent = moveComponent;
            _config = config;
            _pickupView = pickupView;
            _pickupItemProcessor = pickupItemProcessor;

            _pickupView.OnPickupTaken += HandlePickupTaken;
        }

        private void HandlePickupTaken()
        {
            //pass the item to pickup processor
            _pickupItemProcessor.ProcessPickupItem(_config);
            //destroy the pickup
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}