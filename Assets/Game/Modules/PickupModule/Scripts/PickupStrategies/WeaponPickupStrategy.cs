using System;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class WeaponPickupStrategy : IPickupStrategy
    {
        public Type GetConfigType()
        {
            return typeof(WeaponPickupConfigData);
        }

        public void ProcessPickup(IPickupConfigData pickupData)
        {
            if (pickupData is WeaponPickupConfigData weaponData)
            {
                Debug.Log("Processing weapon pickup from " + weaponData);
            }
        }
    }
}