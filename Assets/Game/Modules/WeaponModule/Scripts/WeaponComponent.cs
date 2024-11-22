using System;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletLauncher _bulletLauncher;
        private GameObject _projectilePrefab;
        private Transform[] _firePoints;
        private float _fireRate;
        private float _projectileSpeed;

        private float _timer;

        public WeaponComponent(BulletLauncher bulletLauncher)
        {
            _bulletLauncher = bulletLauncher;
        }

        public void Setup(WeaponConfig weaponConfig, Transform[] firePoints)
        {
            if (weaponConfig == null)
            {
                throw new ArgumentNullException(nameof(weaponConfig));
            }

            if (firePoints.Length == 0)
            {
                throw new ArgumentException("At least one fire point is required", nameof(firePoints));
            }

            WeaponData weaponData = weaponConfig.GetWeaponData();
            _projectilePrefab = weaponData.ProjectileData.ProjectilePrefab;
            _projectileSpeed = weaponData.ProjectileData.ProjectileSpeed;
            _firePoints = firePoints;
            _fireRate = weaponData.FireRate;
        }

        public void Fire(float deltaTime)
        {
            if (_timer <= 0)
            {
                LaunchBullet();
                _timer = _fireRate;
            }
            
            _timer -= deltaTime;
        }

        private void LaunchBullet()
        {
            foreach (Transform firePoint in _firePoints)
            {
                //ToDO: Temp implementation. Will be replaced with proper classes.
                _bulletLauncher.LaunchBullet(_projectilePrefab,firePoint, _projectileSpeed);
            }
        }

    }
}