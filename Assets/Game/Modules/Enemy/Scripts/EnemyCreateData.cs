using UnityEngine;
using UnityEngine.Splines;

namespace SpaceShooter.Game.Enemy
{
    public struct EnemyCreateData
    {
        public Vector3 SpawnPosition { get; private set; }
        public Quaternion SpawnRotation { get; private set; }
        public SplineContainer SplineContainer { get; private set; }
        public EnemyData EnemyData { get; private set; }

        public EnemyCreateData(Vector3 spawnPosition, Quaternion spawnRotation, SplineContainer splineContainer,
            EnemyData enemyData)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            SplineContainer = splineContainer;
            EnemyData = enemyData;
        }
    }
}