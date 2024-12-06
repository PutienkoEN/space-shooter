﻿using System;
using Game.Modules.BulletModule.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class BulletSpawner
    {
        public event Action<BulletEntity> OnNewBullet;
        private readonly IFactory<float, BulletEntity> _bulletFactory;

        public BulletSpawner(IFactory<float, BulletEntity> bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        
        public void LaunchBullet(Transform firePoint, float speed, int damage)
        {
            BulletEntity bulletEntity = _bulletFactory.Create(speed);
            bulletEntity.LaunchBullet(firePoint.position, firePoint.rotation, firePoint.up, damage);
            
            OnNewBullet?.Invoke(bulletEntity);
        }
    }
}