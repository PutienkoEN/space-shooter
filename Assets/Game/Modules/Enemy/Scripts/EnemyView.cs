using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.Common.Scripts;
using UnityEngine;
using UnityEngine.Splines;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action<IDamageable> OnDealDamage;
        public event Action<int> OnTakeDamage;

        private Collider _collider;

        [SerializeField] private SplineAnimate splineAnimate;

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

        public Collider GetCollider()
        {
            return _collider;
        }

        public SplineAnimate GetSplineAnimate()
        {
            return splineAnimate;
        }

        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}