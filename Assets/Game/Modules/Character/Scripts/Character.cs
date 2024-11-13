using UnityEngine;

namespace Input
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMoveComponent characterMoveComponent;
        [SerializeField] private Collider collider;

        public void Move(Vector3 targetPosition)
        {
            characterMoveComponent.Move(targetPosition);
        }

        public Vector3 GetSize()
        {
            return collider.bounds.size;
        }
    }
}