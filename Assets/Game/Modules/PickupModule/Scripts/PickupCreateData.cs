using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public struct PickupCreateData
    {
        public readonly float Speed;
        public Vector3 SpawnPosition;
        public Quaternion SpawnRotation;
        public readonly IPickupViewView IPickupPrefab;

        public PickupCreateData(
            Vector3 spawnPosition, 
            Quaternion spawnRotation, 
            IPickupViewView iPickupPrefab, 
            float speed)
        {
            SpawnPosition = spawnPosition;
            SpawnRotation = spawnRotation;
            IPickupPrefab = iPickupPrefab;
            Speed = speed;
        }
    }
}