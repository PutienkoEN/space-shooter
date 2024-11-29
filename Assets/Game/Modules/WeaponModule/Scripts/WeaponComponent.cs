using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform[] _firePoints;
        private readonly float _fireRate;
        private readonly float _projectileSpeed;
        private readonly int _layer;
        private readonly int _damage;

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
            _fireRate = weaponData.FireRate;
            _damage = weaponData.Damage;
            _firePoints = firePoints;
            _layer = layer;
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
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed, _layer, _damage);
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