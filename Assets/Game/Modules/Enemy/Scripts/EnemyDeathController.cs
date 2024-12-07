using Game.Modules.AnimationModule.Scripts;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyManager _enemyManager;
        private readonly EffectsAnimator _effectsAnimator;

        [Inject]
        public EnemyDeathController(
            EnemyEntity enemyEntity, 
            IEnemyManager enemyManager, 
            EffectsAnimator effectsAnimator)
        {
            _enemyEntity = enemyEntity;
            _enemyManager = enemyManager;
            _effectsAnimator = effectsAnimator;

            _enemyEntity.HealthComponent.OnDeath += HandleOnDeath;
        }

        private void HandleOnDeath()
        {
            _effectsAnimator.PlayExplosion(_enemyEntity.GetCurrentPosition(), DestroyEnemy);
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);
            _enemyEntity.HealthComponent.OnDeath -= DestroyEnemy;
        }
    }
}