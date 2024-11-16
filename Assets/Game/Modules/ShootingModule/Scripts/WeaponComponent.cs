using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponent : IGameListener, IGameTickable
    {
        public bool CanShoot { get; private set; }
        private readonly Transform _weaponsParent;
        private Weapon _activeWeapon;
        private Weapon _weapon;

        public WeaponComponent(
            WeaponConfig defaultWeapon, 
            Transform weaponsParent, 
            Weapon weapon)
        {
            WeaponData weaponData = defaultWeapon.GetWeaponData();
            _weaponsParent = weaponsParent;
            _weapon = weapon;
            EquipWeapon(weaponData);
            SetCanShoot(true);
        }
        
        public void SetCanShoot(bool value)
        {
            CanShoot = value;
        }
        
        private void SetActiveWeapon(Weapon weapon)
        {
            _activeWeapon = weapon;
        }
        
        public void EquipWeapon(WeaponData weaponData)
        {
            if (_weaponsParent.transform.childCount > 0)
            {
                GameObject currentWeapon = _weaponsParent.transform.GetChild(0).gameObject;
                Object.Destroy(currentWeapon);
            }
            GameObject weaponObj = Object.Instantiate(weaponData.WeaponPrefab, _weaponsParent);
            _weapon.InitiateWeapon(weaponData, weaponObj);
            SetActiveWeapon(_weapon);
        }
        
        private void SetIsFiring(bool value)
        {
            _activeWeapon.IsFiring = value;
        }
        
        public void Tick(float deltaTime)
        {
            SetIsFiring(true);
            _activeWeapon.Fire();
        }
    }
}