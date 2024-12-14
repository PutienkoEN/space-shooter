using Game.PickupModule.Scripts;
using GSpaceShooter.Game.Level.Events;
using UnityEngine;

namespace SpaceShooter.Game.Level.Events
{
    public sealed class PickupSpawnLevelEventConfig : ILevelEventConfig<PickupSpawnLevelEventData>
    {
        [Header("Movement and Coordinates")] [SerializeReference]
        private Transform _spawnPoint;

        [Header("Enemy Data")] [SerializeField]
        private PickupView _pickupPrefab;
        
        public PickupSpawnLevelEventData GetData()
        {
            return new PickupSpawnLevelEventData(
                _spawnPoint.position,
                _spawnPoint.rotation,
                _pickupPrefab);
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