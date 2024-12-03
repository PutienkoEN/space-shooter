// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.Common.Scripts;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action<IDamageable> OnDealDamage;
        public event Action<int> OnTakeDamage;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
            var colliderHandler = GetComponentInChildren<ChildColliderHandler>();
            if (colliderHandler != null)
            {
                colliderHandler.SetEntityView(this);
            }
        }

        public void HandleTriggerEnter(Collider other)
        {
            var damageable = other.GetComponentInParent<IDamageable>();
            OnDealDamage?.Invoke(damageable);
        }

        public void TakeDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }

        public Collider GetCollider()
        {
            return _collider;
        }

        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}