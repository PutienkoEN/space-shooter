using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupManager : IGameTickable
    {
        private readonly List<PickupEntity> _pickupItems = new();
        private readonly PickupEntityFactory _pickupEntityFactory;

        public PickupManager(PickupEntityFactory pickupEntityFactory)
        {
            _pickupEntityFactory = pickupEntityFactory;
        }

        public PickupEntity CreatePickupItem(PickupCreateData pickupData)
        {
            PickupEntity pickupEntity = _pickupEntityFactory.CreatePickupEntity(pickupData);
            _pickupItems.Add(pickupEntity);
            return pickupEntity;
        }

        public void Tick(float deltaTime)
        {
            foreach (var pickup in _pickupItems)
            {
               pickup.Update(deltaTime); 
            }
        }
    }
}