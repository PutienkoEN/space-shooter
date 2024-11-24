using System;
using Game.Modules.BulletModule.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class BulletSpawner
    {
        public event Action<BulletEntity> OnNewBullet;
        private BulletEntity.Factory _newBulletFactory;

        public BulletSpawner(BulletEntity.Factory newBulletFactory)
        {
            _newBulletFactory = newBulletFactory;
        }
        
        public void LaunchBullet(Transform firePoint, float speed)
        {
            // Bullet bullet = _bulletFactory.Create();
            // BulletComponent bulletComponent = bullet.GetBulletComponent();

            BulletEntity bulletEntity = _newBulletFactory.Create(speed);
            BulletView bulletComponent = bulletEntity.GetView();
            
            bulletComponent.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
            
            OnNewBullet?.Invoke(bulletEntity);
            
        }
    }
}