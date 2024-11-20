using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponCreator : IWeaponCreator
    {
        public IWeapon CreateWeapon(WeaponData weaponData)
        {
            //TODO : Instantiate new gameobject here;
            IWeapon weapon = new Weapon();
            weapon.InitiateWeapon(weaponData);
            return weapon;
        }

        public void DestroyWeapon(GameObject weapon)
        {
            Object.Destroy(weapon);
        }
    }
}