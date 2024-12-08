using Game.Modules.AnimationModule.Scripts;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public sealed class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyManager _enemyManager;
        private readonly EffectsAnimator _effectsAnimator;
        private readonly IEnemyView _enemyView;

        [Inject]
        public EnemyDeathController(
            EnemyEntity enemyEntity, 
            IEnemyView enemyView,
            IEnemyManager enemyManager, 
            EffectsAnimator effectsAnimator)
        {
            _enemyEntity = enemyEntity;
            _enemyView = enemyView;
            _enemyManager = enemyManager;
            _effectsAnimator = effectsAnimator;

            _enemyEntity.HealthComponent.OnDeath += HandleOnDeath;
        }

        private void HandleOnDeath()
        {
            _enemyView.SetActive(false);
            _effectsAnimator.PlayExplosion(_enemyEntity.GetCurrentPosition(), DestroyEnemy);
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);
            _enemyEntity.HealthComponent.OnDeath -= DestroyEnemy;
        }
    }
}