using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Components
{
    public class HealthComponent
    {
        public event Action OnDeath;
        private int _health;

        [Inject]
        public HealthComponent(int health)
        {
            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (_health <= 0)
            {
                Debug.Log("Health is zero, can't take damage.");
                return;
            }

            _health = Mathf.Max(_health - damage, 0);
            if (_health == 0)
            {
                OnDeath?.Invoke();
            }
        }
    }
}