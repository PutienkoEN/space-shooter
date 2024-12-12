using Zenject;

namespace SpaceShooter.Game.Enemy
{
    public class EnemyEntityFactory
    {
        private EnemyViewFactory _enemyViewFactory;

        public EnemyEntityFactory(EnemyViewFactory enemyViewFactory)
        {
            _enemyViewFactory = enemyViewFactory;
        }

        public EnemyEntity Create(EnemyCreateData enemyCreateData)
        {
            var enemyView = _enemyViewFactory.Create(enemyCreateData);
            return enemyView.GetComponent<GameObjectContext>().Container.Resolve<EnemyEntity>();
        }
    }
}