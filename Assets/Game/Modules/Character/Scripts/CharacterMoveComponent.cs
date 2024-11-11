using System;
using UnityEngine;

namespace Input
{
    [Serializable]
    public class CharacterMoveComponent
    {
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float speed;

        public void Move(Vector3 targetPosition)
        {
            var moveTowards = Vector3.MoveTowards(rigidbody.position, targetPosition, Time.fixedDeltaTime * speed);
            rigidbody.MovePosition(moveTowards);
        }
    }
}