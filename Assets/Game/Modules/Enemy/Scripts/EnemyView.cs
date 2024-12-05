// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using System;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView, IDamagable
    {
        public event Action<int> OnTakeDamage;
        
        public int GetLayer()
        {
            return gameObject.layer;
        }

        public void InvokeOnDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }

        public Collider GetCollider()
        {
            return GetComponentInChildren<Collider>();
        }

        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
        
    }
}