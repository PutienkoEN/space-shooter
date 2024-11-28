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
            Debug.Log("collided with on trigger : " + LayerMask.LayerToName(other.gameObject.layer));
            OnCollision?.Invoke(other);
        }
        
        private void OnCollisionEnter(Collision other)
        {
           
            if (other.gameObject.layer == gameObject.layer)
            {
                // Ignore trigger event for same-layer objects
                return;
            }
            Debug.Log("collided with on collision : " + LayerMask.LayerToName(other.gameObject.layer));
            // OnCollision?.Invoke(other);
        }
    }
}