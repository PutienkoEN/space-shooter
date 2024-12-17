
using System;

namespace Game.PickupModule.Scripts
{
    public interface IPickupStrategy
    {
        public Type GetConfigType();
        public void ProcessPickup(IPickupConfigData pickupData);
    }
}