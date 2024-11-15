using System;
using UnityEngine;

namespace SpaceShooter.Background
{
    [Serializable]
    public sealed class BackgroundData
    {
        public float speed;
        public int zDistance;
        public Material material;
        public GameObject prefab;
    }
}