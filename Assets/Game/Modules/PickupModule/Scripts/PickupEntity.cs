using SpaceShooter.Game.Components;
using SpaceShooter.Game.Player;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        
        private readonly MoveComponent _moveComponent;
        private readonly IPickupView _pickupView;
        private readonly PlayerManager _playerManager;

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupView pickupView, 
            PlayerManager playerManager)
        {
            _moveComponent = moveComponent;
            _pickupView = pickupView;
            _playerManager = playerManager;

            _pickupView.OnPickupTaken += HandlePickupTaken;
        }

        private void HandlePickupTaken(PickupItem pickupItem)
        {
            //pass the item to Player's pickup processor
            //destroy the pickup
        }

        public void Update(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}