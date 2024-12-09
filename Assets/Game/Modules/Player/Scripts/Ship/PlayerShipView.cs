using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.Common.Scripts;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public sealed class PlayerShipView : MonoBehaviour, IPlayerShipView
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
            if (damageable != null)
            {
                OnDealDamage?.Invoke(damageable);
            }
        }
        
        public void TakeDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }
        
        public Transform GetTransform()
        {
            return transform;
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}