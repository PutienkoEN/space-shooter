using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyView _enemyView;
        private readonly IEnemyManager _enemyManager;

        [Inject]
        public EnemyDeathController(EnemyEntity enemyEntity, IEnemyView enemyView, IEnemyManager enemyManager)
        {
            _enemyEntity = enemyEntity;
            _enemyManager = enemyManager;
            _enemyView = enemyView;

            // We want to play death sound only in case we destroyed enemy.
            // But there also case when it just leaves the screen and disposed. So we add play sound only in case of Death.
            _enemyEntity.HealthComponent.OnDeath += _enemyView.PlayDeathSound;
            _enemyEntity.HealthComponent.OnDeath += DestroyEnemy;
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);

            _enemyEntity.HealthComponent.OnDeath -= DestroyEnemy;
            _enemyEntity.HealthComponent.OnDeath -= _enemyView.PlayDeathSound;
        }
    }
}