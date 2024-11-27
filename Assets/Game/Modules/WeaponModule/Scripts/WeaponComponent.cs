using System;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletSpawner _bulletSpawner;
        private Transform[] _firePoints;
        private IWeaponView _weaponView;
        private float _fireRate;
        private float _projectileSpeed;

        private float _timer;

        public WeaponComponent(
            BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }

        public void Setup(WeaponConfig weaponConfig, IWeaponView weaponView)
        {
            if (weaponConfig == null)
            {
                throw new ArgumentNullException(nameof(weaponConfig));
            }

            if (weaponView.GetFirePoints().Length == 0)
            {
                throw new ArgumentException("At least one fire point is required", nameof(weaponView));
            }

            WeaponData weaponData = weaponConfig.GetWeaponData();
            _projectileSpeed = weaponData.ProjectileData.ProjectileSpeed;
            _weaponView = weaponView;
            // _firePoints = weaponView.GetFirePoints();
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
            foreach (Transform firePoint in _weaponView.GetFirePoints())
            {
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed, _weaponView.GetLayer());
            }
        }
        
        public class Factory : PlaceholderFactory<WeaponComponent>{}

    }
}