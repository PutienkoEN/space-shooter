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
        public IWeaponComponent CreateWeapon(
            WeaponConfig weaponConfig, 
            Transform parentEntity,
            LayerMask entityLayer)
        {
            IWeaponView weaponView = CreateWeaponView(weaponConfig, parentEntity);
            
            IWeaponComponent weaponComponent = _weaponComponentFactory.Create(
                weaponConfig,
                weaponView.GetFirePoints(),
                entityLayer);
           
            return weaponComponent;
        }

        private WeaponView CreateWeaponView(
            WeaponConfig weaponConfig, 
            Transform parentEntity)
        {
            WeaponData weaponData = weaponConfig.GetWeaponData();
            Transform weaponParent = SetWeaponParent(parentEntity);
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