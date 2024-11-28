using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponCreator
    {
        public IWeaponComponent CreateWeapon(
            WeaponConfig weaponConfig, 
            Transform parentTransform,
            LayerMask entityLayer);
    }
}