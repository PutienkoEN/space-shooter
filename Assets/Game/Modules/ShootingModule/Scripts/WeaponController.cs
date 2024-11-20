using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponController : IGameListener, IGameTickable
    {
        private readonly IWeaponShooter _weaponShooter;
        private readonly IWeaponCreator _weaponCreator;

        public WeaponController(
            WeaponConfig defaultWeapon)
        {
            _weaponCreator = new WeaponCreator();
            IWeapon weapon = _weaponCreator.CreateWeapon(defaultWeapon.GetWeaponData());
            _weaponShooter = new WeaponShooter();
            _weaponShooter.SetActiveWeapon(weapon);
        }
        
        public void Tick(float deltaTime)
        {
            _weaponShooter.Shoot(deltaTime);
        }
        
    }
}