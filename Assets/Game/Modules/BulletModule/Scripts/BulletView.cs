using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class BulletView : MonoBehaviour
    {
        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}