using System;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class TempColliderMono : MonoBehaviour, IDamagable
    {
        public event Action<int> OnDamage;

        public int health = 100;

        private void Awake()
        {
            OnDamage += HandleDamage;
        }

        private void HandleDamage(int damage)
        {
            health -= damage;
            Debug.Log(health);
        }

        public int GetLayer()
        {
            return gameObject.layer;
        }

        public void InvokeOnDamage(int damage)
        {
            OnDamage?.Invoke(damage);
        }

        public void GetDamage(int damage)
        {
            Debug.Log("collider got damage from bullet : " + damage);
        }
    }
}