using System;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Input
{
    [Serializable]
    public class CharacterMoveComponent
    {
        [SerializeField] private Transform transform;
        [SerializeField] private float speed;

        [Inject]
        public CharacterMoveComponent(Transform transform, float speed)
        {
            this.transform = transform;
            this.speed = speed;
        }

        public void Move(Vector3 targetPosition)
        {
            var moveTowards = Vector3.MoveTowards(transform.position, targetPosition, Time.fixedDeltaTime * speed);
            transform.Translate(moveTowards);
        }
    }
}