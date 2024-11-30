using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform[] _firePoints;
        private readonly int _layer;
        private readonly float _fireRate;
        private readonly float _projectileSpeed;

        private float _timer;

        public WeaponComponent(
            BulletSpawner bulletSpawner,
            WeaponConfig weaponConfig,
            Transform[] firePoints,
            int layer)
        {
            _bulletSpawner = bulletSpawner;
            
            WeaponData weaponData = weaponConfig.GetWeaponData();
            _projectileSpeed = weaponData.ProjectileData.ProjectileSpeed;
            _firePoints = firePoints;
            _layer = layer;
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
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed, _layer);
            }
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
                    firePoints,
                    layer);
                
                return weaponComponent;
            }
        }
    }
}