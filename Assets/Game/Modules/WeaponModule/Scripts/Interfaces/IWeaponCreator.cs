using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponCreator
    {
        public IWeaponComponent CreateWeapon(
            ITargetStrategy targetStrategy,
            WeaponData weaponData,
            Transform parentTransform);
    }
}