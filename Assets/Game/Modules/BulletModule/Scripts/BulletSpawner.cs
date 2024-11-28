using System;
using Game.Modules.BulletModule.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class BulletSpawner
    {
        public event Action<BulletEntity> OnNewBullet;
        private readonly IFactory<float, LayerMask, BulletEntity> _bulletFactory;

        public BulletSpawner(IFactory<float, LayerMask, BulletEntity> bulletFactory)
        {
            _bulletFactory = bulletFactory;
        }
        
        public void LaunchBullet(Transform firePoint, float speed, LayerMask layerMask)
        {
            if (firePoint == null)
            {
                throw new ArgumentNullException(nameof(firePoint));
            }
            BulletEntity bulletEntity = _bulletFactory.Create(speed, layerMask);
            // bulletEntity.SetLayer(layerMask);
            bulletEntity.LaunchBullet(firePoint.position, firePoint.rotation, firePoint.up);
            
            OnNewBullet?.Invoke(bulletEntity);
        }
    }
}