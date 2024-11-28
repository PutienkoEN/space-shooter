using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeaponComponent
    {
        private readonly BulletSpawner _bulletSpawner;
        private readonly Transform[] _firePoints;
        private readonly LayerMask _layerMask;
        private readonly float _fireRate;
        private readonly float _projectileSpeed;

        private float _timer;

        public WeaponComponent(
            BulletSpawner bulletSpawner,
            WeaponConfig weaponConfig,
            Transform[] firePoints,
            LayerMask layerMask)
        {
            _bulletSpawner = bulletSpawner;
            
            WeaponData weaponData = weaponConfig.GetWeaponData();
            _projectileSpeed = weaponData.ProjectileData.ProjectileSpeed;
            _firePoints = firePoints;
            _layerMask = layerMask;
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
                _bulletSpawner.LaunchBullet(firePoint, _projectileSpeed, _layerMask);
            }
        }
        
        public class Factory : PlaceholderFactory<WeaponConfig, Transform[], LayerMask, WeaponComponent>
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
                LayerMask layer)
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