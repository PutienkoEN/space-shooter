using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.Common.Scripts
{
    public sealed class ChildColliderHandler : MonoBehaviour
    {
        private ICollidable _iCollidable;
        
        public void SetEntityView(ICollidable iCollidable)
        {
            _iCollidable = iCollidable;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _iCollidable?.HandleTriggerEnter(other);
        }

        
    }
}