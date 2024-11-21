using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController : IGameListener, IGameTickable
    {
        private readonly IWeapon _activeWeapon;
        
        public WeaponController(
            WeaponConfig defaultWeapon,
            IWeaponCreator weaponCreator,
            GameObject player)
        {
            _activeWeapon = weaponCreator.CreateWeapon(defaultWeapon.GetWeaponData(), player);
        }
        
        public void Tick(float deltaTime)
        {
            _activeWeapon.Fire(deltaTime);
        }
        
    }
}