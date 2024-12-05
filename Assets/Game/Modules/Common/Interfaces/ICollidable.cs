using UnityEngine;

namespace Game.Modules.Common.Interfaces
{
    public interface ICollidable
    {
        public void HandleTriggerEnter(Collider other);
    }
}