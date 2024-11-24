using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponCreator : IWeaponCreator
    {
        private const string WEAPON_PARENT_NAME = "WeaponParent";
        private WeaponComponent.Factory _weaponComponentFactory;
        public WeaponCreator(WeaponComponent.Factory weaponComponentFactory)
        {
            _weaponComponentFactory = weaponComponentFactory;
        }
        public IWeaponComponent CreateWeapon(WeaponDataConfig weaponDataConfig, GameObject parentEntity)
        {
            if (weaponDataConfig == null)
            {
                throw new System.ArgumentNullException(nameof(weaponDataConfig));
            }
            
            if (parentEntity == null)
            {
                throw new System.ArgumentNullException(nameof(parentEntity));
            }

            Transform weaponParent = SetWeaponParent(parentEntity);

            WeaponView weaponView = SetWeaponView(weaponDataConfig, weaponParent);
            
            IWeaponComponent weaponComponent = _weaponComponentFactory.Create();
            weaponComponent.Setup(weaponDataConfig, weaponView.firePoints);
            return weaponComponent;
        }

        private WeaponView SetWeaponView(WeaponDataConfig weaponDataConfig, Transform weaponParent)
        {
            WeaponData weaponData = weaponDataConfig.GetWeaponData();
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