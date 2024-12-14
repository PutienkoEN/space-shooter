using System;
using Game.Modules.BulletModule;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        public event Action OnShoot;

        private readonly BulletSpawner _bulletSpawner;
        private readonly ITargetStrategy _targetStrategy;

        private readonly Transform[] _firePoints;
        private readonly float _fireRate;
        private readonly float _projectileSpeed;
        private readonly int _damage;
        private readonly float _fireStartDelay = 0.5f;

        private readonly BulletView _projectilePrefab;
        private float _timer;

        public WeaponComponent(
            BulletSpawner bulletSpawner,
            WeaponData weaponData,
            Transform[] firePoints,
            ITargetStrategy targetStrategy)
        {
            _bulletSpawner = bulletSpawner;

            _projectileSpeed = weaponData.ProjectileSpeed;
            _fireRate = weaponData.FireRate;
            _damage = weaponData.Damage;
            _firePoints = firePoints;
            _targetStrategy = targetStrategy;
            _projectilePrefab = weaponData.ProjectilePrefab;
            _timer = _fireStartDelay; //Is used to delay start of shooting when new weapon is created
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
                var launch = CreateLaunchBulletData(firePoint);
                _bulletSpawner.LaunchBullet(launch);
            }

            OnShoot?.Invoke();
        }

        private LaunchBulletData CreateLaunchBulletData(Transform firePoint)
        {
            var bulletData = new BulletData(_damage, _projectileSpeed);
            return new LaunchBulletData(
                _projectilePrefab,
                firePoint.position,
                _targetStrategy.GetTarget(),
                firePoint.rotation,
                bulletData);
        }

        public class Factory : PlaceholderFactory<ITargetStrategy, WeaponData, Transform[], WeaponComponent>
        {
        }
    }
}