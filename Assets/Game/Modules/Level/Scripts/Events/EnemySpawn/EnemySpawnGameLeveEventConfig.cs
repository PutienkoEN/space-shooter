using System;
using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    [Serializable]
    public class EnemySpawnGameLeveEventConfig : IGameLevelEventConfig<EnemySpawnGameLevelEventData>
    {
        [Header("Coordinates")] [SerializeField]
        private Transform spawnPoint;

        [Header("Spawn")] [SerializeField] private EnemyConfig enemyConfig;

        [SerializeField] private float spawnIntervalInSeconds = 1;
        [SerializeField] private int numberOfEnemiesToSpawn = 4;

        public EnemySpawnGameLevelEventData GetData() => new(
            spawnPoint.position,
            spawnPoint.rotation,
            enemyConfig.GetData(),
            spawnIntervalInSeconds,
            numberOfEnemiesToSpawn);
    }

    public class EnemySpawnGameLevelEventData : IGameLevelEventData
    {
        public Vector3 SpawnPosition { get; private set; }
        public Quaternion SpawnRotation { get; private set; }
        public EnemyData EnemyData { get; private set; }
        public float SpawnIntervalInSeconds { get; private set; }
        public int NumberOfEnemiesToSpawn { get; private set; }

        public EnemySpawnGameLevelEventData(
            Vector3 spawnPosition,
            Quaternion spawnRotation,
            EnemyData enemyData,
            float spawnIntervalInSeconds,
            int numberOfEnemiesToSpawn)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            EnemyData = enemyData;
            SpawnIntervalInSeconds = spawnIntervalInSeconds;
            NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
        }
    }
}