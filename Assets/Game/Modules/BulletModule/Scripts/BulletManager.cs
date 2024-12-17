using System;
using System.Collections.Generic;
using Game.Modules.Common.Interfaces;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.Modules.BulletModule
{
    public sealed class BulletManager : IGameTickable, IDisposable
    {
        public IReadOnlyList<ISimpleEntity> Bullets =>
            _bullets; //ToDo: consider removing it later. Used only in Tests for now;

        private readonly List<ISimpleEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        private int _counter = -1;

        public BulletManager(
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

        private void RemoveBullet(ISimpleEntity bulletEntity)
        {
            if (!_bullets.Contains(bulletEntity))
            {
                return;
            }
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
                ISimpleEntity bullet = _bullets[_counter];
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