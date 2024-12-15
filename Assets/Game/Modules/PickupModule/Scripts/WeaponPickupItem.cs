using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public class WeaponPickupItem : PickupItem
    {
        [SerializeField] private WeaponConfig weaponConfig;

        public WeaponConfig GetWeaponConfig()
        {
            return weaponConfig;
        }
    }
}