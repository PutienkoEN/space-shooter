using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponCreator : IWeaponCreator
    {
        public IWeapon CreateWeapon(WeaponData weaponData, GameObject parentEntity)
        {
            Transform weaponParent;
            
            if (parentEntity == null)
            {
                throw new System.ArgumentNullException(nameof(parentEntity));
            }

            Transform weaponParentTransform = parentEntity.transform.Find("WeaponParent");
            if (weaponParentTransform != null)
            {
                weaponParent = weaponParentTransform;
            }
            else
            {
                var newWeaponParent = new GameObject("WeaponParent");
                newWeaponParent.transform.SetParent(parentEntity.transform);
                newWeaponParent.transform.localPosition = Vector3.zero;
                weaponParent = newWeaponParent.transform;
            }
            
            WeaponView weaponView = Object.Instantiate(weaponData.Prefab, weaponParent);
            Transform[] firePoints = weaponView.firePoints;
            IWeapon weapon = new WeaponComponent();
            weapon.Setup(weaponData, firePoints);
            return weapon;
        }
    }
}