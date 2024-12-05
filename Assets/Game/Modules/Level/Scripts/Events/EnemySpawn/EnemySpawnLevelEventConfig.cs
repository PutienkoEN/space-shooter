using System;
using GSpaceShooter.Game.Level.Events;
using SpaceShooter.Game.Enemy;
using UnityEngine;
using UnityEngine.Splines;

namespace SpaceShooter.Game.Level.Events
{
    [Serializable]
    public class EnemySpawnLevelEventConfig : ILevelEventConfig<EnemySpawnLevelEventData>
    {
        [Header("Movement and Coordinates")] [SerializeReference]
        private Transform spawnPoint;

        [SerializeField] public SplineContainer splineContainer;

        [Header("Number of enemies and how often")] [SerializeField]
        private float spawnIntervalInSeconds = 1;

        [SerializeField] private int numberOfEnemiesToSpawn = 4;


        [Header("Enemy Data")] [SerializeField]
        private EnemyConfig enemyConfig;


        public EnemySpawnLevelEventData GetData()
        {
            return new EnemySpawnLevelEventData(
                spawnPoint.position,
                spawnPoint.rotation,
                splineContainer,
                enemyConfig.GetData(),
                spawnIntervalInSeconds,
                numberOfEnemiesToSpawn);
        }
    }

    public class EnemySpawnLevelEventData : ILevelEventData
    {
        public EnemyCreateData EnemyCreateData { get; private set; }
        public float SpawnIntervalInSeconds { get; private set; }
        public int NumberOfEnemiesToSpawn { get; private set; }

        public EnemySpawnLevelEventData(
            Vector3 spawnPosition,
            Quaternion spawnRotation,
            SplineContainer splineContainer,
            EnemyData enemyData,
            float spawnIntervalInSeconds,
            int numberOfEnemiesToSpawn)
        {
            EnemyCreateData = new EnemyCreateData(spawnPosition, spawnRotation, splineContainer, enemyData);
            SpawnIntervalInSeconds = spawnIntervalInSeconds;
            NumberOfEnemiesToSpawn = numberOfEnemiesToSpawn;
        }
    }
}