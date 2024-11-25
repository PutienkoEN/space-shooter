using System;
using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Object = System.Object;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletController : IGameTickable, IDisposable
    {
        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        private OutOfBoundsController _outOfBoundsController;
        private int counter = -1;
        
        public BulletController(
            BulletSpawner bulletSpawner,
            OutOfBoundsController outOfBoundsController)
        {
            _bulletSpawner = bulletSpawner;
            _outOfBoundsController = outOfBoundsController;
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
            if (!_bullets.Contains(obj))
                return;
            int bulletIndex = _bullets.IndexOf(obj);
            if (counter >= bulletIndex)
            {
                counter--;
            }
            _bullets.RemoveAt(bulletIndex);
        }

        public void Tick(float deltaTime)
        {
            for (counter = 0; counter < _bullets.Count; counter++)
            {
                BulletEntity bullet = _bullets[counter];
                bullet.OnUpdate(deltaTime);
                
                if (!_outOfBoundsController.IsInBounds(bullet.GetColliderRect()))
                {
                    RemoveBullet(bullet);
                    bullet.Dispose();
                }
            }

            counter = -1;
        }

        public void Dispose()
        {
            _bulletSpawner.OnNewBullet -= AddNewBullet;
        }
    }
}