using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    //ToDO: Temp class. Will be replaced.
    public class BulletLauncher
    {
        public void LaunchBullet(GameObject projectilePrefab, Transform firePoint, float speed)
        {
            GameObject bullet = InstantiateBullet(projectilePrefab, firePoint);//ToDo: Temporary
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            MoveBullet(rb, firePoint.up, speed);//ToDo: Temporary
        }
        
        private GameObject InstantiateBullet(GameObject projectilePrefab, Transform firePoint)
        {
            return Object.Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
           
        }
        
        private void MoveBullet(Rigidbody rb, Vector3 direction, float speed)
        {
            rb.linearVelocity = direction * speed;
        }
    }
}