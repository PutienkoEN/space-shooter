using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponComponent
    {
        public void Setup(WeaponConfig weaponConfig, IWeaponView weaponView);
        public void Fire(float deltaTime);
    }
}