using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Components
{
    public class HealthComponent
    {
        public event Action OnDeath;
        private float _health;

        [Inject]
        public HealthComponent(float health)
        {
            _health = health;
        }

        public void TakeDamage(float damage)
        {
            if (_health <= 0)
            {
                Debug.Log("Health is zero, can't take damage.");
                return;
            }

            var resultHealth = _health - damage;
            if (resultHealth <= 0)
            {
                _health = 0;
                OnDeath?.Invoke();
            }

            _health = resultHealth;
        }
    }
}