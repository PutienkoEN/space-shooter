using Game.Modules.AnimationModule.Scripts;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public sealed class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyView _enemyView;
        readonly IEnemyManager _enemyManager;
        private readonly EffectsAnimator _effectsAnimator;

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

            // We want to play death sound only in case we destroyed enemy.
            // But there also case when it just leaves the screen and disposed. So we add play sound only in case of Death.
            _enemyEntity.HealthComponent.OnDeath += HandleOnDeath;
        }

        private void HandleOnDeath()
        {
            _enemyView.PlayDeathSound();
            _enemyView.SetActive(false);
            _effectsAnimator.PlayExplosion(_enemyView.GetCollider().transform, DestroyEnemy);
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);
            _enemyEntity.HealthComponent.OnDeath -= DestroyEnemy;
        }
    }
}