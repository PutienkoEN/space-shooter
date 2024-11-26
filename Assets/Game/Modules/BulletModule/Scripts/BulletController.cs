using System;
using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.CameraUtility;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Object = System.Object;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletController : IGameTickable, IDisposable
    {
        public IReadOnlyList<BulletEntity> Bullets => _bullets;
        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        private WorldCoordinates _worldCoordinates;
        private int _counter = -1;
        
        public BulletController(
            BulletSpawner bulletSpawner,
            WorldCoordinates worldCoordinates)
        {
            _bulletSpawner = bulletSpawner;
            _worldCoordinates = worldCoordinates;
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
                BulletEntity bullet = _bullets[_counter];
                bullet.OnUpdate(deltaTime);
                
                if (!_worldCoordinates.IsInBounds(bullet.GetColliderRect()))
                {
                    RemoveBullet(bullet);
                    bullet.Dispose();
                }
            }

            _counter = -1;
        }

        public void Dispose()
        {
            _bulletSpawner.OnNewBullet -= AddNewBullet;
        }
    }
}