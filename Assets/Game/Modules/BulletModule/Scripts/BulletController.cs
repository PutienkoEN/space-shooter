using System;
using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletController : IGameTickable, IDisposable
    {
        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;

        private int _counter = -1;
        
        public BulletController(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
            _bulletSpawner.OnNewBullet += AddNewBullet;
        }

        private void AddNewBullet(BulletEntity obj)
        {
            if (obj != null)
            {
                _bullets.Add(obj);
            }
        }
        
        private void RemoveBullet(BulletEntity obj)
        {
            int bulletIndex = _bullets.IndexOf(obj);
            if (_counter >= bulletIndex)
            {
                _counter--;
            }
            _bullets.RemoveAt(bulletIndex);
        }

        public void Tick(float deltaTime)
        {
            for (_counter = 0; _counter < _bullets.Count; _counter++)
            {
                var bullet = _bullets[_counter];
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