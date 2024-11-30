// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView
    {
        public Collider GetCollider();
        public void Destroy();
    }
    
    public class EnemyView : MonoBehaviour, IEnemyView, IDamagable
    {
        public event Action<int> OnDamage;
        public int GetLayer()
        {
            return gameObject.layer;
        }

        public void InvokeOnDamage(int damage)
        {
            OnDamage?.Invoke(damage);
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