using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.Common.Scripts;
using UnityEngine;

namespace Game.Modules.BulletModule
{
    public sealed class BulletView : MonoBehaviour, IBulletView
    {
        public event Action<IDamageable> OnDealDamage;

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
            var damagable = other.GetComponentInParent<IDamageable>();
            if (damagable != null)
            {
                OnDealDamage?.Invoke(damagable);
            }
        }

        public Collider GetCollider()
        {
            return GetComponentInChildren<Collider>();
        }

        public Transform GetTransform()
        {
            return transform;
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}