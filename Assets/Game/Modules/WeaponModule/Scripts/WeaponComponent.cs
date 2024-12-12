using System;
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
        private float _fireStartDelay = 0.5f;

        private float _timer;

        public WeaponComponent(
            BulletSpawner bulletSpawner,
            WeaponConfig weaponConfig,
            Transform[] firePoints)
        {
            _bulletSpawner = bulletSpawner;

            WeaponData weaponData = weaponConfig.GetWeaponData();
            _projectileSpeed = weaponData.ProjectileSpeed;
            _fireRate = weaponData.FireRate;
            _damage = weaponData.Damage;
            _firePoints = firePoints;
            
            _timer = _fireStartDelay;//Is used to delay start of shooting when new weapon is created
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
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed, _damage);
            }

            OnShoot?.Invoke();
        }

        public class Factory : PlaceholderFactory<WeaponConfig, Transform[], int, WeaponComponent>
        {
            private readonly BulletSpawner _bulletSpawner;

            [Inject]
            public Factory(BulletSpawner bulletSpawner)
            {
                _bulletSpawner = bulletSpawner;
            }

            public override WeaponComponent Create(
                WeaponConfig config,
                Transform[] firePoints,
                int layer)
            {
                WeaponComponent weaponComponent = new WeaponComponent(
                    _bulletSpawner,
                    config,
                    firePoints);

                return weaponComponent;
            }
        }
    }
}