using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public struct PickupCreateData
    {
        public Vector3 SpawnPosition;
        public Quaternion SpawnRotation;
        public readonly PickupView PickupPrefab;

        public PickupCreateData(
            Vector3 spawnPosition, 
            Quaternion spawnRotation, 
            PickupView pickupPrefab)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            PickupPrefab = pickupPrefab;
            
        }
    }
}