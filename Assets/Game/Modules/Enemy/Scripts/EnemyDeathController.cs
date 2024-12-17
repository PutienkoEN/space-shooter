using Game.Modules.AnimationModule.Scripts;
using Game.Modules.Scores;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public sealed class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyManager _enemyManager;
        private readonly EffectsAnimator _effectsAnimator;
        private readonly HealthComponent _healthComponent;
        private readonly ScoreComponent _scoreComponent;

        [Inject]
        public EnemyDeathController(
            EnemyEntity enemyEntity,
            IEnemyView enemyView,
            IEnemyManager enemyManager,
            EffectsAnimator effectsAnimator,
            HealthComponent healthComponent,
            ScoreComponent scoreComponent)
        {
            _enemyEntity = enemyEntity;
            _enemyView = enemyView;
            _enemyManager = enemyManager;
            _effectsAnimator = effectsAnimator;
            _healthComponent = healthComponent;
            _scoreComponent = scoreComponent;

            // We want to play death sound only in case we destroyed enemy.
            // But there also case when it just leaves the screen and disposed. So we add play sound only in case of Death.
            _healthComponent.OnDeath += HandleOnDeath;
        }

        private void HandleOnDeath()
        {
            _scoreComponent.GiveScore();
            _enemyView.PlayDeathSound();
            _effectsAnimator.PlayExplosion(_enemyView.GetCollider().transform, DestroyEnemy);
            _enemyEntity.SetIsActive(false);
            _enemyView.SetActive(false);
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);
            _healthComponent.OnDeath -= DestroyEnemy;
        }
    }
}