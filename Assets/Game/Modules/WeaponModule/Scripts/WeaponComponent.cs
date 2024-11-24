using System;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletSpawner _bulletSpawner;
        private GameObject _projectilePrefab;
        private Transform[] _firePoints;
        private float _fireRate;
        private float _projectileSpeed;

        private float _timer;

        public WeaponComponent(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }

        public void Setup(WeaponDataConfig weaponDataConfig, Transform[] firePoints)
        {
            if (weaponDataConfig == null)
            {
                throw new ArgumentNullException(nameof(weaponDataConfig));
            }

            if (firePoints.Length == 0)
            {
                throw new ArgumentException("At least one fire point is required", nameof(firePoints));
            }

            WeaponData weaponData = weaponDataConfig.GetWeaponData();
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
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed);
            }
        }
        
        public class Factory : PlaceholderFactory<WeaponComponent>{}

    }
}