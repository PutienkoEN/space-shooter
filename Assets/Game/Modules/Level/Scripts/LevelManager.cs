using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    // TODO 2024-11-28 Temporary class for using manager -> will be extended to manage level based on configuration.
    public class LevelManager
    {
        private readonly EnemyManager _enemyManager;

        [Inject]
        public LevelManager(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public async void StartLevel(GameLevelData gameLevelData)
        {
            var enemyEventHandlers = gameLevelData.GameLevelEvents
                .ConvertAll(enemyEvent => new EnemySpawnEventHandler(_enemyManager, enemyEvent));


            foreach (var enemyEventHandler in enemyEventHandlers)
            {
                await enemyEventHandler.Start();
            }
        }
    }
}