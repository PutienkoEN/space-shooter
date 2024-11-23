using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletPoolController : MonoBehaviour
    {
        private IMemoryPool<BulletComponent> _bulletPool;

        [Inject]
        public void Construct(IMemoryPool<BulletComponent> bulletPool)
        {
            Debug.Log("BulletPoolController");
            _bulletPool = bulletPool;
        }
        
        [Button]
        public void FireBullet()
        {
            var bullet = _bulletPool.Spawn();
            bullet.transform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
        }
    }
    
    
    
}