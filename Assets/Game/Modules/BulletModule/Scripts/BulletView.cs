using System;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    [RequireComponent(typeof(Collider))]
    public class BulletView : MonoBehaviour
    {
        public bool Collided { get; private set; }
        public LayerMask enemyLayerMask;
        public void DestroyBullet()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision other)
        {
            if ((enemyLayerMask.value & (1 << other.gameObject.layer)) != 0 && !Collided)
            {
                Collided = true;
            }
            else
            {
                Collided = false;
            }
        }
    }
}