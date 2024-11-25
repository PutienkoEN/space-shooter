using System;
using Game.Modules.BulletModule.Scripts;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class BulletSpawner
    {
        public event Action<BulletEntity> OnNewBullet;
        private readonly BulletEntity.Factory _bulletFactory;

        public BulletSpawner(BulletEntity.Factory bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        
        public void LaunchBullet(Transform firePoint, float speed)
        {
            BulletEntity bulletEntity = _bulletFactory.Create(speed);
            bulletEntity.LaunchBullet(firePoint.position, firePoint.rotation);
            
            OnNewBullet?.Invoke(bulletEntity);
        }
    }
}