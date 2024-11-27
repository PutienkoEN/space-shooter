using Cysharp.Threading.Tasks;
using Game.Modules.EnemyGroup.Scripts;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    // TODO 2024-11-28 Temporary class for using manager -> will be extended to manage level based on configuration.
    public class LevelManager
    {
        private readonly LevelData _levelData;
        private readonly EnemyManager _enemyManager;

        [Inject]
        public LevelManager(LevelData levelData, EnemyManager enemyManager)
        {
            _levelData = levelData;
            _enemyManager = enemyManager;
        }

        public async UniTaskVoid StartLevel()
        {
            var enemiesData = _levelData.Enemies;
            foreach (var enemyData in enemiesData)
            {
                _enemyManager.CreateEnemy(_levelData.SpawnPosition, _levelData.Rotation, enemyData);
                await UniTask.Delay(_levelData.SpawnIntervalInSeconds * 1000);
            }
        }
    }
}