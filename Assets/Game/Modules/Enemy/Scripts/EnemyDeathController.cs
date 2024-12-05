using Game.Modules.AnimationModule.Scripts;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyManager _enemyManager;
           
        private EffectsAnimator _effectsAnimator;

        [Inject]
        public EnemyDeathController(EnemyEntity enemyEntity, IEnemyManager enemyManager)
        {
            _enemyEntity = enemyEntity;
            _enemyManager = enemyManager;

            _enemyEntity.HealthComponent.OnDeath += HandleOnDeath;
            
            _effectsAnimator = new EffectsAnimator();
        }

        private void HandleOnDeath()
        {
            Debug.Log("In DestroyEnemy");
            if (_effectsAnimator != null)
            {
                _effectsAnimator.PlayExplosion(DestroyEnemy);
            }
            else
            {
                DestroyEnemy();
            }

        }

        private void DestroyEnemy()
        {
            Debug.Log("In KillEnemy");
            _enemyManager.DestroyEnemy(_enemyEntity);
            _enemyEntity.HealthComponent.OnDeath -= HandleOnDeath;
        }
    }
}