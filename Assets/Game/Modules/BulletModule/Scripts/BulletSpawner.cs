using System;
using UnityEngine;

namespace Game.Modules.BulletModule
{
    public sealed class BulletSpawner
    {
        public event Action<BulletEntity> OnNewBullet;
        private readonly BulletEntityFactory _bulletBulletEntityFactory;

        public BulletSpawner(BulletEntityFactory bulletBulletEntityFactory)
        {
            _bulletBulletEntityFactory = bulletBulletEntityFactory;
        }

        public void LaunchBullet(Transform firePoint, BulletView bulletView, BulletData bulletData)
        {
            var bulletEntity = _bulletBulletEntityFactory.Create(bulletView, bulletData);
            bulletEntity.LaunchBullet(firePoint.position, firePoint.rotation, firePoint.up);
            OnNewBullet?.Invoke(bulletEntity);
        }
    }
}