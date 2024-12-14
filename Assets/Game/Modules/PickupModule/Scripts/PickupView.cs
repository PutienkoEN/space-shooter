using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupView : MonoBehaviour
    {
        public int MoveSpeed => moveSpeed;
        
        [SerializeField] private int moveSpeed;
        [SerializeField] private PickupItem pickupItem;
        
    }
}