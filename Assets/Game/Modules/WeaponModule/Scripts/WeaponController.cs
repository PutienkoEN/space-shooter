using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController : IWeaponController
    {
        private readonly IWeaponCreator _weaponCreator;
        private readonly ITargetStrategy _targetStrategy;
        private readonly Transform _parentTransform;
        private IWeaponComponent _activeWeapon;

        public WeaponController(
            IWeaponCreator weaponCreator, 
            ITargetStrategy targetStrategy, 
            WeaponData weaponData, 
            Transform parentTransform)
        {
            _weaponCreator = weaponCreator;
            _targetStrategy = targetStrategy;
            _parentTransform = parentTransform;
            
            EquipWeapon(weaponData);
        }

        public void Tick(float deltaTime)
        {
            if (_activeWeapon == null)
            {
                return;
            }
            _activeWeapon.Fire(deltaTime);
        }
        
        public void ChangeWeapon(WeaponData weaponData)
        {
            DeleteCurrentWeapon();
            EquipWeapon(weaponData);
        }

        private void EquipWeapon(WeaponData weaponData)
        {
            _activeWeapon = _weaponCreator.CreateWeapon(_targetStrategy, weaponData, _parentTransform);
        }

        private void DeleteCurrentWeapon()
        {
            if (_activeWeapon is IWeaponDestructible destructible)
            {
                destructible.Destroy();
                _activeWeapon = null;
            }
        }
    }
}