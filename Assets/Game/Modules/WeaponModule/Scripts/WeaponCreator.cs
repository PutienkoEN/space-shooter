using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponCreator : IWeaponCreator
    {
        private const string WEAPON_PARENT_NAME = "WeaponParent";
        private IFactory<WeaponConfig, Transform[], int, WeaponComponent> _weaponComponentFactory;

        public WeaponCreator(IFactory
            <WeaponConfig, Transform[], int, WeaponComponent> weaponComponentFactory)
        {
            _weaponComponentFactory = weaponComponentFactory;
        }

        public IWeaponComponent CreateWeapon(
            WeaponConfig weaponConfig,
            Transform parentTransform,
            int entityLayer)
        {
            IWeaponView weaponView = CreateWeaponView(weaponConfig, parentTransform);

            IWeaponComponent weaponComponent = _weaponComponentFactory.Create(
                weaponConfig,
                weaponView.GetFirePoints(),
                entityLayer);

            weaponComponent.OnShoot += weaponView.PlayShootSound;
            return weaponComponent;
        }

        private WeaponView CreateWeaponView(
            WeaponConfig weaponConfig,
            Transform parentTransform)
        {
            WeaponData weaponData = weaponConfig.GetWeaponData();
            Transform weaponParent = SetWeaponParent(parentTransform);
            WeaponView weaponView = Object.Instantiate(weaponData.WeaponPrefab, weaponParent);
            return weaponView;
        }

        private Transform SetWeaponParent(Transform parentTransform)
        {
            Transform weaponParent;

            Transform weaponParentTransform = parentTransform.Find(WEAPON_PARENT_NAME);
            if (weaponParentTransform != null)
            {
                weaponParent = weaponParentTransform;
            }
            else
            {
                var newWeaponParent = new GameObject(WEAPON_PARENT_NAME);
                newWeaponParent.transform.SetParent(parentTransform.transform);
                newWeaponParent.transform.localPosition = Vector3.zero;
                weaponParent = newWeaponParent.transform;
            }

            return weaponParent;
        }
    }
}