using System;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponent : IGameListener, IGameTickable
    {
        public bool CanShoot { get; private set; }
        private readonly GameObject _defaultWeapon;
        private readonly Transform _weaponsParent;
        private Weapon _activeWeapon;

        public WeaponComponent(GameObject defaultWeapon, Transform weaponsParent)
        {
            _defaultWeapon = defaultWeapon;
            _weaponsParent = weaponsParent;
            SetDefaultWeapon();
            SetCanShoot(true);
        }
        
        public void SetCanShoot(bool value)
        {
            CanShoot = value;
        }
        
        public void EquipWeapon(GameObject weaponPrefab)
        {
            Weapon weapon = Object.Instantiate(weaponPrefab, _weaponsParent).GetComponent<Weapon>();
            weapon.transform.SetParent(_weaponsParent, false);
            _activeWeapon = weapon;
        }
        
        private void SetDefaultWeapon()
        {
            if(_defaultWeapon == null)
            {
                Debug.LogError("Specify default weapon");
            }
            else
            {
                EquipWeapon(_defaultWeapon);
            }
        }
        
        private void SetIsFiring(bool value)
        {
            _activeWeapon.isFiring = value;
        }

        public void Tick(float deltaTime)
        {
            SetIsFiring(CanShoot);
            _activeWeapon.Fire();
        }
    }
}