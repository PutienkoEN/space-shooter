using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.Components
{
    public class CollisionDamageComponent : IDisposable
    {
        private readonly int _collisionDamage;
        private readonly IDamageDealer _enemyView;
        private readonly IEnemyEntity _entity;
        private bool _isInGame;

        public CollisionDamageComponent(
            int collisionDamage, 
            IDamageDealer enemyView, 
            IEnemyEntity entity)
        {
            _collisionDamage = collisionDamage;
            _enemyView = enemyView;
            _entity = entity;

            _entity.OnInGameStateChanged += SetEntityState;
            _enemyView.OnDealDamage += DealDamage;
        }

        private void SetEntityState(bool value)
        {
            _isInGame = value;
        }

        public void DealDamage(IDamageable target)
        {
            if (!_isInGame)
            {
                return;
            }
            target.TakeDamage(_collisionDamage);
        }

        public void Dispose()
        {
            _entity.OnStateChanged -= SetEntityState;
            _enemyView.OnDealDamage -= DealDamage;
        }
    }
}