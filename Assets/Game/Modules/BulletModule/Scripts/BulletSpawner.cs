using System;
using Game.Modules.ShootingModule;

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

        public void LaunchBullet(LaunchBulletData launchData)
        {
            var bulletEntity = _bulletBulletEntityFactory.Create(launchData.BulletPrefab, launchData.BulletData);
            bulletEntity.LaunchBullet(launchData.SpawnPosition, launchData.Rotation, launchData.TargetPosition);

            OnNewBullet?.Invoke(bulletEntity);
        }
    }
}