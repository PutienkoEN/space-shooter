using System;
using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.Modules.BulletModule
{
    public sealed class BulletController : IGameTickable, IDisposable
    {
        public IReadOnlyList<BulletEntity> Bullets =>
            _bullets; //ToDo: consider removing it later. Used only in Tests for now;

        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        private int _counter = -1;

        public BulletController(
            BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;

            _bulletSpawner.OnNewBullet += AddNewBullet;
        }

        private void AddNewBullet(BulletEntity bulletEntity)
        {
            if (bulletEntity != null)
            {
                _bullets.Add(bulletEntity);
                bulletEntity.OnDestroy += RemoveBullet;
            }
        }

        private void RemoveBullet(BulletEntity bulletEntity)
        {
            if (!_bullets.Contains(bulletEntity))
                return;
            int bulletIndex = _bullets.IndexOf(bulletEntity);
            if (_counter >= bulletIndex)
            {
                _counter--;
            }

            _bullets.RemoveAt(bulletIndex);
            bulletEntity.OnDestroy -= RemoveBullet;
        }

        public void Tick(float deltaTime)
        {
            for (_counter = 0; _counter < _bullets.Count; _counter++)
            {
                BulletEntity bullet = _bullets[_counter];
                bullet.OnUpdate(deltaTime);
            }

            _counter = -1;
        }

        public void Dispose()
        {
            _bulletSpawner.OnNewBullet -= AddNewBullet;
        }
    }
}