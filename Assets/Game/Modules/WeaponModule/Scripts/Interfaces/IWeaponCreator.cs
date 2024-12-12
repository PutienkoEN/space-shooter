using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponCreator
    {
        public IWeaponComponent CreateWeapon(WeaponData weaponData, Transform parentTransform);
    }
}