using UnityEngine;

namespace Input
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private CharacterMoveComponent characterMoveComponent;

        public void Move(Vector3 targetPosition)
        {
            characterMoveComponent.Move(targetPosition);
        }
    }
}