using System;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController
    {
        private readonly IWeaponComponent _activeIWeaponComponent;
        
        public WeaponController(
            WeaponDataConfig weaponDataConfig,
            IWeaponCreator weaponCreator,
            GameObject player)
        {
            if (weaponDataConfig == null)
                throw new ArgumentNullException(nameof(weaponDataConfig), "Weapon data cannot be null.");
            
            if (weaponCreator == null)
                throw new ArgumentNullException(nameof(weaponCreator), "Weapon creator cannot be null.");
            
            if (player == null)
                throw new ArgumentNullException(nameof(player), "Player object cannot be null.");
            
            _activeIWeaponComponent = weaponCreator.CreateWeapon(weaponDataConfig, player);
            
            Debug.Log("WeaponController initialized.");
        }
        
        public void Tick(float deltaTime)
        {
            _activeIWeaponComponent.Fire(deltaTime);
        }
        
    }
}