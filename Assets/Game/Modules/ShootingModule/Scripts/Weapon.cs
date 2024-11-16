using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class Weapon : IGameListener, IGameTickable
    {
        private LayerMask _targetLayer;
        private GameObject _weaponObj;
        private GameObject _bulletPrefab;
        private float _projectileSpeed;
        private float _fireRate;

        private float _timer;
        public bool IsFiring;

        public Weapon(WeaponData weaponData, GameObject weaponObj)
        {
            _targetLayer = weaponData.TargetLayer;
            _weaponObj = weaponObj;
            _bulletPrefab = weaponData.BulletPrefab;
            _projectileSpeed = weaponData.ProjectileSpeed;
            _fireRate = weaponData.FireRate;
        }

        private void LaunchBullet()
        {
            Debug.Log("launch bullet");
            foreach (Transform source in _weaponObj.transform)
            {
                GameObject bullet = Object.Instantiate(_bulletPrefab, source.position, source.rotation);
                bullet.GetComponent<Rigidbody>().linearVelocity = source.transform.up * _projectileSpeed;
            }
        }
        
        public void Fire()
        {
            Debug.Log("fire");
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
                _timer -= Time.deltaTime;
            }
        }
    }
}