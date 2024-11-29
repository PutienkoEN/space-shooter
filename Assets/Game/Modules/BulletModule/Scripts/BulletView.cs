using System;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class BulletView : MonoBehaviour
    {
        public event Action<Collider> OnCollision;
        
        public void DestroyBullet()
        {
            Destroy(gameObject);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == gameObject.layer)
            {
                // Ignore trigger event for same-layer objects
                return;
            }
            OnCollision?.Invoke(other);
        }
    }
}