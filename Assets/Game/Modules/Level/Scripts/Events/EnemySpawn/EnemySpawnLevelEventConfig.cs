using System;
using GSpaceShooter.Game.Level.Events;
using SpaceShooter.Game.Enemy;
using UnityEngine;

namespace SpaceShooter.Game.Level.Events
{
    [Serializable]
    public class EnemySpawnLevelEventConfig : ILevelEventConfig<EnemySpawnLevelEventData>
    {
        [Header("Coordinates")] [SerializeField]
        private Transform spawnPoint;

        [Header("Spawn")] [SerializeField] private EnemyConfig enemyConfig;

        [SerializeField] private float spawnIntervalInSeconds = 1;
        [SerializeField] private int numberOfEnemiesToSpawn = 4;

        public EnemySpawnLevelEventData GetData()
        {
            return new EnemySpawnLevelEventData(
                spawnPoint.position,
                spawnPoint.rotation,
                enemyConfig.GetData(),
                spawnIntervalInSeconds,
                numberOfEnemiesToSpawn);
        }
    }

    public class EnemySpawnLevelEventData : ILevelEventData
    {
        public Vector3 SpawnPosition { get; private set; }
        public Quaternion SpawnRotation { get; private set; }
        public EnemyData EnemyData { get; private set; }
        public float SpawnIntervalInSeconds { get; private set; }
        public int NumberOfEnemiesToSpawn { get; private set; }

        public EnemySpawnLevelEventData(
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