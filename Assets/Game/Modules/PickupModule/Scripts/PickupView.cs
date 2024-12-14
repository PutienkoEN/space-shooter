using UnityEngine;
using UnityEngine.Serialization;

namespace Game.PickupModule.Scripts
{
    public class PickupView : MonoBehaviour
    {
        public int MoveSpeed => moveSpeed;
        
        [SerializeField] private int moveSpeed;
        [SerializeField] private PickupItem pickupItem;
        
    }
}