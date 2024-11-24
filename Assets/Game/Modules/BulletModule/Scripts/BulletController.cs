using System;
using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletController : IDisposable
    {
        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        public BulletController(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
            _bulletSpawner.OnNewBullet += HandleNewBullet;
        }

        private void HandleNewBullet(BulletEntity obj)
        {
            _bullets.Add(obj);
        }

        public void Tick(float deltaTime)
        {
            foreach (BulletEntity bullet in _bullets)
            {
                bullet.OnUpdate(deltaTime);
            }
        }

        public void Dispose()
        {
            _bulletSpawner.OnNewBullet -= HandleNewBullet;
        }
    }
}