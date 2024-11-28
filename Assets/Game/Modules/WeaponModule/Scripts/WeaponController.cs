﻿using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController
    {
        private readonly IWeaponComponent _activeIWeaponComponent;
        
        public WeaponController(
            WeaponConfig weaponConfig,
            IWeaponCreator weaponCreator,
            Transform parentTransform,
            LayerMask parentLayer)
        {
            _activeIWeaponComponent = weaponCreator.CreateWeapon(
                weaponConfig, 
                parentTransform,
                parentLayer);
        }
        
        public void Tick(float deltaTime)
        {
            _activeIWeaponComponent.Fire(deltaTime);
        }
        
    }
}