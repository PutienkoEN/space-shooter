using System;
using Cysharp.Threading.Tasks;
using SpaceShooter.Game.Enemy;

namespace SpaceShooter.Game.Level.Events
{
    public class EnemySpawnEventHandler : IGameEventHandler
    {
        private readonly EnemyManager _enemyManager;
        private readonly EnemySpawnLevelEventData _spawnData;

        public EnemySpawnEventHandler(EnemyManager enemyManager, EnemySpawnLevelEventData spawnData)
        {
            _enemyManager = enemyManager;
            _spawnData = spawnData;
        }

        public async UniTask Start()
        {
            await SpawnEnemies();
        }

        private async UniTask SpawnEnemies()
        {
            var enemyCreateData = _spawnData.EnemyCreateData;
            for (var i = 0; i < _spawnData.NumberOfEnemiesToSpawn; i++)
            {
                _enemyManager.CreateEnemy(enemyCreateData);
                var millisecondsToWait = ConvertToMilliseconds(_spawnData.SpawnIntervalInSeconds);
                await UniTask.Delay(millisecondsToWait);
            }
        }

        private static int ConvertToMilliseconds(float seconds)
        {
            var milliseconds = seconds * 1000;
            return Convert.ToInt32(milliseconds);
        }
    }
}