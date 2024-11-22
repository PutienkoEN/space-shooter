using System;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController : IGameListener, IGameTickable
    {
        private readonly IWeaponComponent _activeIWeaponComponent;
        
        public WeaponController(
            WeaponConfig weaponConfig,
            IWeaponCreator weaponCreator,
            GameObject player)
        {
            if (weaponConfig == null)
                throw new ArgumentNullException(nameof(weaponConfig), "Weapon data cannot be null.");
            
            if (weaponCreator == null)
                throw new ArgumentNullException(nameof(weaponCreator), "Weapon creator cannot be null.");
            
            if (player == null)
                throw new ArgumentNullException(nameof(player), "Player object cannot be null.");
            
            _activeIWeaponComponent = weaponCreator.CreateWeapon(weaponConfig, player);
        }
        
        public void Tick(float deltaTime)
        {
            _activeIWeaponComponent.Fire(deltaTime);
        }
        
    }
}