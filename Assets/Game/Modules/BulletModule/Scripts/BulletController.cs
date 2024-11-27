using System;
using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.CameraUtility;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletController : IGameTickable, IDisposable
    {
        public IReadOnlyList<BulletEntity> Bullets => _bullets;//ToDo: consider removing it later. Used only in Tests for now;
        private readonly List<BulletEntity> _bullets = new();
        private readonly BulletSpawner _bulletSpawner;
        private readonly WorldCoordinates _worldCoordinates;
        private int _counter = -1;
        
        public BulletController(
            BulletSpawner bulletSpawner,
            WorldCoordinates worldCoordinates)
        {
            _bulletSpawner = bulletSpawner;
            _worldCoordinates = worldCoordinates;
            
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
            if (deltaTime <= 0)
            {
                throw new ArgumentException("deltaTime must be greater than 0.", nameof(BulletController));
            }
            
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