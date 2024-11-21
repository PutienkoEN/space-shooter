using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponComponent : IWeapon
    {
        private GameObject _projectilePrefab;
        private Transform[] _firePoints;
        private float _fireRate;
        private float _projectileSpeed;

        private float _timer;
        public bool IsFiring;

        public void Setup(WeaponData weaponData, Transform[] firePoints)
        {
            _projectilePrefab = weaponData.ProjectileConfig.GetProjectileData().ProjectilePrefab;
            _projectileSpeed = weaponData.ProjectileConfig.GetProjectileData().ProjectileSpeed;
            _firePoints = firePoints;
            _fireRate = weaponData.FireRate;
            _timer = _fireRate;
        }

        public void Fire(float deltaTime)
        {
            if (!IsFiring)
            {
               IsFiring = true;
               LaunchBullet();
            }
            
            _timer -= deltaTime;
            
            if (_timer <= 0)
            {
                LaunchBullet();
                _timer = _fireRate;
            }
        }

        private void LaunchBullet()
        {
            foreach (Transform firePoint in _firePoints)
            {
                GameObject bullet = InstantiateBullet(firePoint);//ToDo: Temporary
                Rigidbody rb = bullet.GetComponent<Rigidbody>();
                MoveBullet(rb, firePoint.up, _projectileSpeed);//ToDo: Temporary
            }
        }
        
        //ToDo: Sample method for spawning bullets. Will be replaced by Pool.
        private GameObject InstantiateBullet(Transform firePoint)
        {
            return Object.Instantiate(_projectilePrefab, firePoint.position, firePoint.rotation);
           
        }
        
        //ToDo: Sample method for moving bullets. Will be replaced by Move component.
        private void MoveBullet(Rigidbody rb, Vector3 direction, float speed)
        {
            rb.linearVelocity = direction * _projectileSpeed;
        }

    }
}