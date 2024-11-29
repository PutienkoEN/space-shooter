using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyDeathController
    {
        private readonly EnemyEntity _enemyEntity;
        private readonly IEnemyManager _enemyManager;

        [Inject]
        public EnemyDeathController(EnemyEntity enemyEntity, IEnemyManager enemyManager)
        {
            _enemyEntity = enemyEntity;
            _enemyManager = enemyManager;

            _enemyEntity.HealthComponent.OnDeath += DestroyEnemy;
        }

        private void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(_enemyEntity);
            _enemyEntity.HealthComponent.OnDeath -= DestroyEnemy;
        }
    }
}