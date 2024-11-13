using System;
using UnityEngine;

namespace SpaceShooter.Background
{
    [Serializable]
    public sealed class BackgroundConfig
    {
        public float speed;
        public int zDistance;
        public GameObject prefab;
    }
}