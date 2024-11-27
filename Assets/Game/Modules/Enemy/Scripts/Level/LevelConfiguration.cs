using System.Collections.Generic;
using System.Linq;
using Game.Modules.Enemy.Scripts;
using UnityEngine;

namespace Game.Modules.EnemyGroup.Scripts
{
    // TODO 2024-11-28 Class to be split into more configurations in future to handle waves/groups
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/Configuration")]
    public class LevelConfiguration : ScriptableObject
    {
        [SerializeField] private Vector3 spawnPoint = new Vector3(0, 10, 0);
        [SerializeField] private Quaternion rotation = Quaternion.identity;
        [SerializeField] private int spawnIntervalInSeconds = 3;
        [SerializeField] private List<EnemyConfig> enemies;

        public LevelData GetData()
        {
            var enemiesData = enemies
                .Select(enemyConfig => enemyConfig.GetData())
                .ToList();

            return new LevelData(spawnPoint, rotation, spawnIntervalInSeconds, enemiesData);
        }
    }

    public class LevelData
    {
        public Vector3 SpawnPosition { get; private set; }
        public Quaternion Rotation { get; private set; }
        public int SpawnIntervalInSeconds { get; private set; }
        public IReadOnlyList<EnemyData> Enemies { get; private set; }

        public LevelData(
            Vector3 spawnPosition,
            Quaternion rotation,
            int spawnIntervalInSeconds,
            IReadOnlyList<EnemyData> enemies)
        {
            SpawnIntervalInSeconds = spawnIntervalInSeconds;
            SpawnPosition = spawnPosition;
            Rotation = rotation;
            Enemies = enemies;
        }
    }
}