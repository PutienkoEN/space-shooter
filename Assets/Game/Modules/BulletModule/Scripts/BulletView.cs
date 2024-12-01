using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.Common.Scripts;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletView : MonoBehaviour, ICollidable
    {
        public event Action<Collider> OnCollision;

        private void Awake()
        {
            var colliderHandler = GetComponentInChildren<ChildColliderHandler>();
            if (colliderHandler != null)
            {
                colliderHandler.SetEntityView(this);
            }
        }

        public void HandleTriggerEnter(Collider other)
        {
            OnCollision?.Invoke(other);
        }

        public void DestroyBullet()
        {
            Destroy(gameObject);
        }
    }
}