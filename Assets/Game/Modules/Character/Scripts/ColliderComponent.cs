using System;
using UnityEngine;
using Zenject;

namespace Game.Modules.Character.Scripts
{
    [Serializable]
    public class ColliderComponent
    {
        [SerializeField] private Collider collider;

        [Inject]
        public ColliderComponent(Collider collider)
        {
            this.collider = collider;
        }

        public Vector3 GetSize()
        {
            return collider.bounds.size;
        }

        public Vector3 GetPosition()
        {
            return collider.transform.position;
        }
    }
}