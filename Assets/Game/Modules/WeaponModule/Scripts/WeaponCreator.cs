using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponCreator : IWeaponCreator
    {
        private const string WEAPON_PARENT_NAME = "WeaponParent";
        public IWeaponComponent CreateWeapon(WeaponConfig weaponConfig, GameObject parentEntity)
        {
            if (weaponConfig == null)
            {
                throw new System.ArgumentNullException(nameof(weaponConfig));
            }
            
            if (parentEntity == null)
            {
                throw new System.ArgumentNullException(nameof(parentEntity));
            }

            Transform weaponParent = SetWeaponParent(parentEntity);

            WeaponView weaponView = SetWeaponView(weaponConfig, weaponParent);
            
            IWeaponComponent weaponComponent = new WeaponComponent(new BulletLauncher());
            weaponComponent.Setup(weaponConfig, weaponView.firePoints);
            return weaponComponent;
        }

        private WeaponView SetWeaponView(WeaponConfig weaponConfig, Transform weaponParent)
        {
            WeaponData weaponData = weaponConfig.GetWeaponData();
            WeaponView weaponView = Object.Instantiate(weaponData.Prefab, weaponParent);
            return weaponView;
        }

        private Transform SetWeaponParent(GameObject parentEntity)
        {
            Transform weaponParent;

            Transform weaponParentTransform = parentEntity.transform.Find(WEAPON_PARENT_NAME);
            if (weaponParentTransform != null)
            {
                weaponParent = weaponParentTransform;
            }
            else
            {
                var newWeaponParent = new GameObject(WEAPON_PARENT_NAME);
                newWeaponParent.transform.SetParent(parentEntity.transform);
                newWeaponParent.transform.localPosition = Vector3.zero;
                weaponParent = newWeaponParent.transform;
            }

            return weaponParent;
        }
    }
}