using UnityEngine;

namespace SpaceShooter.Background
{
    public struct BackgroundData
    {
        public float Speed { get; private set; }
        public int ZDistance { get; private set; }
        public Material Material { get; private set; }
        public GameObject Prefab { get; private set; }

        public BackgroundData(
            float speed, 
            int zDistance, 
            Material material, 
            GameObject prefab)
        {
            Speed = speed;
            ZDistance = zDistance;
            Material = material;
            Prefab = prefab;
        }
    }
}