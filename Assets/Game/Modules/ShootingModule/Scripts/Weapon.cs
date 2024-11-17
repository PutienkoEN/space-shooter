using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class Weapon : IGameListener, IGameTickable
    {
        private LayerMask _targetLayer;
        public GameObject WeaponObj { get; private set; }
        private GameObject _bulletPrefab;
        private float _projectileSpeed;
        private float _fireRate;

        private float _timer;
        public bool IsFiring;

        public void InitiateWeapon(WeaponData weaponData, GameObject weaponObj)
        {
            _targetLayer = weaponData.TargetLayer;
            WeaponObj = weaponObj;
            _bulletPrefab = weaponData.BulletPrefab;
            _projectileSpeed = weaponData.ProjectileSpeed;
            _fireRate = weaponData.FireRate;
        }

        private void LaunchBullet()
        {
            foreach (Transform source in WeaponObj.transform)
            {
                GameObject bullet = Object.Instantiate(_bulletPrefab, source.position, source.rotation);
                bullet.GetComponent<Rigidbody>().linearVelocity = source.transform.up * _projectileSpeed;
            }
        }
        
        public void Fire()
        {
            if (IsFiring && _timer <= 0)
            {
                LaunchBullet();
                _timer = _fireRate;
            }
        }

        public void Tick(float deltaTime)
        {
            if (IsFiring)
            {
                _timer -= deltaTime;
            }
        }
    }
}