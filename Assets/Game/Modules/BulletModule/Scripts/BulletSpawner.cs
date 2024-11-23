using Game.Modules.BulletModule.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    //ToDO: Temp class. Will be replaced.
    public class BulletSpawner
    {
        private Bullet.Factory _bulletFactory;
        private BulletFacade.Factory _bulletFacadeFactory;

        public BulletSpawner(Bullet.Factory bulletFactory, BulletFacade.Factory bulletFacadeFactory)
        {
            _bulletFactory = bulletFactory;
            _bulletFacadeFactory = bulletFacadeFactory;
        }
        
        public void LaunchBullet(Transform firePoint, float speed)
        {
            // Bullet bullet = _bulletFactory.Create();
            // BulletComponent bulletComponent = bullet.GetBulletComponent();

            BulletFacade bulletComponent = _bulletFacadeFactory.Create();
            
            bulletComponent.transform.SetPositionAndRotation(firePoint.position, firePoint.rotation);
            
            Rigidbody rb = bulletComponent.GetComponent<Rigidbody>();
            MoveBullet(rb, firePoint.up, speed);//ToDo: Temporary
        }
        
        private void MoveBullet(Rigidbody rb, Vector3 direction, float speed)
        {
            rb.linearVelocity = direction * speed;
        }
    }
}