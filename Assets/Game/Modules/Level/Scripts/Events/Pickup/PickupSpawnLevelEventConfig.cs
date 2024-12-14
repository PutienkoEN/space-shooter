using Game.PickupModule.Scripts;
using GSpaceShooter.Game.Level.Events;
using UnityEngine;

namespace SpaceShooter.Game.Level.Events
{
    public class PickupSpawnLevelEventConfig : ILevelEventConfig<PickupSpawnLevelEventData>
    {
        [Header("Movement and Coordinates")] [SerializeReference]
        private Transform spawnPoint;

        [Header("Enemy Data")] [SerializeField]
        private PickupView pickupPrefab;
        
        public PickupSpawnLevelEventData GetData()
        {
            return new PickupSpawnLevelEventData(
                spawnPoint.position,
                spawnPoint.rotation,
                pickupPrefab);
        }
    }

    public class PickupSpawnLevelEventData : ILevelEventData
    {
        public PickupCreateData PickupCreateData { get; private set; }
        
        public PickupSpawnLevelEventData(
            Vector3 spawnPosition, 
            Quaternion spawnRotation, 
            PickupView pickupPrefab)
        {
            PickupCreateData = new PickupCreateData(
                spawnPosition, 
                spawnRotation, 
                pickupPrefab,
                pickupPrefab.MoveSpeed);
        }
    }
}