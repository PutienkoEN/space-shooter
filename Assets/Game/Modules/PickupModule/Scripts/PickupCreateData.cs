using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public struct PickupCreateData
    {
        public float Speed;
        public Vector3 SpawnPosition;
        public Quaternion SpawnRotation;
        public PickupView PickupPrefab;

        public PickupCreateData(
            Vector3 spawnPosition, 
            Quaternion spawnRotation, 
            PickupView pickupPrefab, 
            float speed)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            PickupPrefab = pickupPrefab;
            Speed = speed;
        }
    }
}