using System.Collections.Generic;
using Game.Modules.Common.Interfaces;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupManager : IGameTickable
    {
        private readonly List<IPickupEntity> _pickupItems = new();
        private readonly PickupEntityFactory _pickupEntityFactory;

        public PickupManager(PickupEntityFactory pickupEntityFactory)
        {
            _pickupEntityFactory = pickupEntityFactory;
        }

        public PickupEntity CreatePickupItem(PickupCreateData pickupData)
        {
            PickupEntity pickupEntity = _pickupEntityFactory.CreatePickupEntity(pickupData);
            _pickupItems.Add(pickupEntity);
            pickupEntity.OnDestroy += DestroyPickup;
            return pickupEntity;
        }

        private void DestroyPickup(IPickupEntity pickupEntity)
        {
            if (!_pickupItems.Contains(pickupEntity))
            {
                return;
            }
            _pickupItems.Remove(pickupEntity);
            pickupEntity.OnDestroy -= DestroyPickup;
        }

        public void Tick(float deltaTime)
        {
            for (var index = _pickupItems.Count -1 ; index >= 0; index--)
            {
                var pickup = _pickupItems[index];
                pickup.OnUpdate(deltaTime);
            }
        }
    }
}