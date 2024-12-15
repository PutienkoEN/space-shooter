using Game.Modules.BulletModule;
using UnityEngine;

namespace Game.Modules.ShootingModule
{
    public struct LaunchBulletData
    {
        public BulletView BulletPrefab { get; private set; }
        public Vector3 SpawnPosition { get; private set; }
        public Vector3 TargetPosition { get; private set; }
        public Quaternion Rotation { get; private set; }
        public BulletData BulletData { get; private set; }

        public LaunchBulletData(
            BulletView bulletPrefab,
            Vector3 spawnPosition,
            Vector3 targetPosition,
            Quaternion rotation,
            BulletData bulletData)
        {
            BulletPrefab = bulletPrefab;
            SpawnPosition = spawnPosition;
            TargetPosition = targetPosition;
            Rotation = rotation;
            BulletData = bulletData;
        }
    }
}