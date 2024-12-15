using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController
    {
        private readonly IWeaponComponent _activeWeapon;

        public WeaponController(IWeaponCreator weaponCreator, ITargetStrategy targetStrategy, WeaponData weaponData, Transform parentTransform)
        {
            _activeWeapon = weaponCreator.CreateWeapon(targetStrategy, weaponData, parentTransform);
        }

        public void Tick(float deltaTime)
        {
            _activeWeapon.Fire(deltaTime);
        }
    }
}