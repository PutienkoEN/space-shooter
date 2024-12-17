using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupManager : IGameTickable
    {
        private readonly PickupEntityFactory _pickupEntityFactory;
        
        private readonly List<IPickupEntity> _pickupItems = new();

        public PickupManager(PickupEntityFactory pickupEntityFactory)
        {
            _pickupEntityFactory = pickupEntityFactory;
        }

        public void CreatePickupItem(PickupCreateData pickupData)
        {
            IPickupEntity pickupEntity = _pickupEntityFactory.CreatePickupEntity(pickupData);
            pickupEntity.OnDestroy += DestroyPickup;
            _pickupItems.Add(pickupEntity);
        }

        public void Tick(float deltaTime)
        {
            for (var index = _pickupItems.Count -1 ; index >= 0; index--)
            {
                var pickup = _pickupItems[index];
                pickup.OnUpdate(deltaTime);
            }
        }
        private void DestroyPickup(IPickupEntity pickupEntity)
        {
            if (!_pickupItems.Contains(pickupEntity))
            {
                Debug.LogWarning($"Tried to destroy a pickup that is not in the pickup list - {pickupEntity}");
                return;
            }
            _pickupItems.Remove(pickupEntity);
            pickupEntity.OnDestroy -= DestroyPickup;
        }

       
    }
}