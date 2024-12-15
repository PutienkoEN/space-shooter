using SpaceShooter.Game.Components;
using SpaceShooter.Game.Player;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity
    {
        private readonly IPickupConfig _config;
        private readonly IPickupView _pickupView;
        private readonly MoveComponent _moveComponent;
        private readonly PlayerManager _playerManager;

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupConfig config,
            PlayerManager playerManager)
        {
            _moveComponent = moveComponent;
            _config = config;
            _playerManager = playerManager;
            
            _pickupView.OnPickupTaken += HandlePickupTaken;
        }
        
        private void HandlePickupTaken(PickupItem pickupItem)
        {
            //pass the item to Player's pickup processor
            //destroy the pickup
        }

        public void OnUpdate(float deltaTime)
        {
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
        }
    }
}