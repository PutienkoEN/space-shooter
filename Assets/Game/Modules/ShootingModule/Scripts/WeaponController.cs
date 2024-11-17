using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponController : IGameListener, IGameTickable
    {
        public bool CanShoot { get; private set; }
        private readonly Transform _weaponsParent;
        private Weapon _activeWeapon;
        private Weapon _weapon;

        private WeaponSpawner _weaponSpawner;

        public WeaponController(
            WeaponConfig defaultWeapon, 
            Transform weaponsParent, 
            Weapon weapon, 
            WeaponSpawner weaponSpawner)
        {
            WeaponData weaponData = defaultWeapon.GetWeaponData();
            _weaponsParent = weaponsParent;
            _weapon = weapon;
            _weaponSpawner = weaponSpawner;
            EquipWeapon(weaponData);
            SetCanShoot(true);
        }
        
        public void Tick(float deltaTime)
        {
            SetIsFiring(true);
            _activeWeapon.Fire();
        }
        
        public void SetCanShoot(bool value)
        {
            CanShoot = value;
        }
        
        public void EquipWeapon(WeaponData weaponData)
        {
            _weaponSpawner.DestroyWeapon(_activeWeapon.WeaponObj);
            var weaponObj = _weaponSpawner.CreateWeapon(weaponData, _weaponsParent);
            
            _weapon.InitiateWeapon(weaponData, weaponObj);
            SetActiveWeapon(_weapon);
        }
        
        private void SetActiveWeapon(Weapon weapon)
        {
            _activeWeapon = weapon;
        }
        
        private void SetIsFiring(bool value)
        {
            _activeWeapon.IsFiring = value;
        }
    }

    public class WeaponSpawner
    {

        public GameObject CreateWeapon(WeaponData weaponData, Transform weaponParent)
        {
            return Object.Instantiate(weaponData.WeaponPrefab, weaponParent);
        }

        public void DestroyWeapon(GameObject weapon)
        {
            Object.Destroy(weapon);
        }
    }
}