using Game.Modules.ShootingModule.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletSpawnHelper : MonoBehaviour
    {
        private BulletSpawner _bulletSpawner;
        
        [Inject]
        public void Construct(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
        }

        [Button]
        public void SpawnBullet(Transform firePoint, float speed)
        {
            _bulletSpawner.LaunchBullet(firePoint, speed);
            // _bulletSpawner.CreateBullet();
        }
    }
}