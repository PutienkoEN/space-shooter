using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeapon
    {
        public void Setup(WeaponData weaponData, Transform[] firePoints);
        public void Fire(float deltaTime);
    }
}