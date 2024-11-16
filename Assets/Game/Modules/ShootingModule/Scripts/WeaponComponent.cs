using System;
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
        private readonly GameObject _defaultWeapon;
        private readonly Transform _weaponsParent;
        private Weapon _activeWeapon;
        private DiContainer _diContainer;

        public WeaponComponent(
            WeaponConfig defaultWeapon, 
            Transform weaponsParent, 
            DiContainer diContainer)
        {
            Debug.Log("weapon component constructed");
            WeaponData weaponData = defaultWeapon.GetWeaponData();
            // _defaultWeapon = weaponData.WeaponPrefab;
            _weaponsParent = weaponsParent;
            _diContainer = diContainer;
            SetDefaultWeapon(diContainer, weaponData);
            SetCanShoot(true);
        }
        
        public void SetCanShoot(bool value)
        {
            CanShoot = value;
        }
        
        public void EquipWeapon(Weapon weapon)
        {
            _activeWeapon = weapon;
        }
        
        private void SetDefaultWeapon(DiContainer container, WeaponData weaponData)
        {
            GameObject weaponObj = Object.Instantiate(weaponData.WeaponPrefab, _weaponsParent);
            Weapon weapon = container.Instantiate<Weapon>(new object[] { weaponData, weaponObj });
            EquipWeapon(weapon);
        }
        
        private void SetIsFiring(bool value)
        {
            _activeWeapon.IsFiring = value;
        }
        
        public void Tick(float deltaTime)
        {
            Debug.Log("ticking");
            //     SetIsFiring(true);
            //     _activeWeapon.Fire();
        }
    }
}