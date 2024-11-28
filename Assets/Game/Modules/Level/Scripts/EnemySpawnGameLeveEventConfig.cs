using System;
using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    [Serializable]
    public class EnemySpawnGameLeveEventConfig
    {
        [Header("Coordinates")] [SerializeField]
        private Transform spawnPoint;

        [Header("Spawn")] [SerializeField] private EnemyConfig enemy;

        [SerializeField] private int spawnIntervalInSeconds = 1;
        [SerializeField] private int numberOfEnemiesToSpawn = 4;

        public EnemySpawnGameLeveEventData GetData() => new(
            spawnPoint.position,
            spawnPoint.rotation.eulerAngles,
            enemy.GetData(),
            spawnIntervalInSeconds,
            numberOfEnemiesToSpawn);
    }

    public class EnemySpawnGameLeveEventData
    {
        public Vector3 SpawnPosition { get; private set; }
        public Vector3 SpawnRotation { get; private set; }
        public EnemyData Enemies { get; private set; }
        public int SpawnIntervalInSeconds { get; private set; }
        public int NumberOfEnemiesToSpawn { get; private set; }

        public EnemySpawnGameLeveEventData(
            Vector3 spawnPosition,
            Vector3 spawnRotation,
            EnemyData enemies,
            int spawnIntervalInSeconds,
            int numberOfEnemiesToSpawn)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            Enemies = enemies;
            SpawnIntervalInSeconds = spawnIntervalInSeconds;
            NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
        }
    }
}