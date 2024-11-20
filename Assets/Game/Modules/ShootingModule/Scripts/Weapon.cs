using System;
using System.Globalization;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Modules.ShootingModule.Scripts
{
    public class Weapon : IWeapon
    {
        private Transform[] _firepoints;
        private float _fireRate;

        private float _timer;
        public bool IsFiring;

        public void InitiateWeapon(WeaponData weaponData)
        {
            _firepoints = weaponData.FirePoints;
            _fireRate = 2f; //TODO: This will be replaced with data from Config;
            _timer = _fireRate;
        }
        
        public void Fire(float deltaTime)
        {
            // Debug.Log("_timer : " + _timer);
            if (!IsFiring)
            {
               IsFiring = true;
               LaunchBullet();
            }
            
            _timer -= deltaTime;
            
            if (_timer <= 0)
            {
                LaunchBullet();
                _timer = _fireRate;
            }
        }

        private void LaunchBullet()
        {
            foreach (Transform firepoint in _firepoints)
            {
               Debug.Log("Launching bullet");
            }
        }

    }

    public interface IWeapon
    {
        public void InitiateWeapon(WeaponData weaponData);
        public void Fire(float deltaTime);
    }
}