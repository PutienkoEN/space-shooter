
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public class WeaponPickupStrategy : IPickupStrategy
    {
        
        public void ProcessPickup(IPickupConfigData pickupData)
        {
            if (pickupData is WeaponPickupConfigData weaponData)
            {
                Debug.Log("Weapon config : " + weaponData.WeaponConfig);
            }
        }
    }
}