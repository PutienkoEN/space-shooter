using System;
using Game.Modules.Common.Interfaces;
using SpaceShooter.Game.Enemy;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Components
{
    public sealed class HealthComponent : IDisposable
    {
        public event Action OnDeath;
        private int _health;
        private bool _isInGame;

        private readonly IDamageable _entityView;
        private readonly IComplexEntity _entity;

        [Inject]
        public HealthComponent(int health, IDamageable entityView, IComplexEntity entity)
        {
            _health = health;
            _entityView = entityView;
            _entity = entity;

            _entity.OnInGameStateChanged += SetInGameState;
            _entityView.OnTakeDamage += TakeDamage;
        }

        private void SetInGameState(bool value)
        {
            _isInGame = value;
        }

        public void TakeDamage(int damage)
        {
            if (!_isInGame || _health <= 0)
            {
                Debug.Log("Not in game or health is zero. Can't take damage.");
                return;
            }

            _health = Mathf.Max(_health - damage, 0);
            if (_health == 0)
            {
                OnDeath?.Invoke();
            }
        }

        public void Dispose()
        {
            _entityView.OnTakeDamage -= TakeDamage;
        }
    }
}