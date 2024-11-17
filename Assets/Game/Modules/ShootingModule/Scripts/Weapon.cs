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
        private Transform[] firepoints;
        private float _fireRate;

        private float _timer;
        public bool IsFiring;

        public void InitiateWeapon(WeaponData weaponData)
        {
            // _fireRate = weaponData.FireRate;
            
        }
        
        public void Fire(float deltaTime)
        {
            if (IsFiring)
            {
                _timer -= deltaTime;
            }
            
            if (IsFiring && _timer <= 0)
            {
                LaunchBullet();
                _timer = _fireRate;
            }
        }

        private void LaunchBullet()
        {
            // foreach (Transform source in WeaponObj.transform)
            // {
            //    Debug.Log("Launching bullet");
            // }
        }

    }

    public interface IWeapon
    {
        public void Fire(float deltaTime);
    }
}