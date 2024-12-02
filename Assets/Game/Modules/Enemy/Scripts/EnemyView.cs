// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using System;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action<int> OnTakeDamage;

        private Collider _collider;

        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();
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