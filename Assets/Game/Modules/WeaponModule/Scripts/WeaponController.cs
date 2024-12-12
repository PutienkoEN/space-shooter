using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController
    {
        private readonly IWeaponComponent _activeWeapon;
        
        public WeaponController(
            WeaponData weaponData,
            IWeaponCreator weaponCreator,
            Transform parentTransform,
            LayerMask parentLayer)
        {
            _activeWeapon = weaponCreator.CreateWeapon(
                weaponData, 
                parentTransform,
                parentLayer);
        }
        
        public void Tick(float deltaTime)
        {
            _activeWeapon.Fire(deltaTime);
        }
        
    }
}