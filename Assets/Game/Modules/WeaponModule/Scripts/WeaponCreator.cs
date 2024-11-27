using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
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
        public IWeaponComponent CreateWeapon(WeaponConfig weaponConfig, IEntityView parentEntity)
        {
            if (weaponConfig == null)
            {
                throw new System.ArgumentNullException(nameof(weaponConfig));
            }
            
            if (parentEntity == null)
            {
                throw new System.ArgumentNullException(nameof(parentEntity));
            }

            Transform weaponParent = SetWeaponParent(parentEntity.GetTransform());

            WeaponView weaponView = SetWeaponView(weaponConfig, weaponParent);

            weaponView.gameObject.layer = parentEntity.GetLayerMask();
            
            IWeaponComponent weaponComponent = _weaponComponentFactory.Create();
            weaponComponent.Setup(weaponConfig, weaponView);
            return weaponComponent;
        }

        private WeaponView SetWeaponView(WeaponConfig weaponConfig, Transform weaponParent)
        {
            WeaponData weaponData = weaponConfig.GetWeaponData();
            WeaponView weaponView = Object.Instantiate(weaponData.Prefab, weaponParent);
            return weaponView;
        }

        private Transform SetWeaponParent(Transform parentEntity)
        {
            Transform weaponParent;

            Transform weaponParentTransform = parentEntity.Find(WEAPON_PARENT_NAME);
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