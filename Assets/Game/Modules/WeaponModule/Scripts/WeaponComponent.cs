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
            Transform[] firePoints)
        {
            _bulletSpawner = bulletSpawner;

            _projectileSpeed = weaponData.ProjectileSpeed;
            _fireRate = weaponData.FireRate;
            _damage = weaponData.Damage;
            _firePoints = firePoints;
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
                var bulletData = new BulletData(_damage, _projectileSpeed);
                _bulletSpawner.LaunchBullet(firePoint, _projectilePrefab, bulletData);
            }

            OnShoot?.Invoke();
        }

        public class Factory : PlaceholderFactory<WeaponData, Transform[], WeaponComponent>
        {
        }
    }
}