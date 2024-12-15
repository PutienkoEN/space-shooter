using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Components
{
    [Serializable]
    public class MoveComponent
    {
        [SerializeField] private Transform transform;
        [SerializeField] private float speed;

        [Inject]
        public MoveComponent(Transform transform, float speed)
        {
            this.transform = transform;
            this.speed = speed;
        }

        public void MoveToTarget(Vector3 target, float deltaTime)
        {
            var moveTowards = Vector3.MoveTowards(transform.position, target, speed * deltaTime);
            transform.position = moveTowards;
        }

        public void MoveToDirection(Vector3 direction, float deltaTime)
        {
            transform.position += direction * (speed * deltaTime);
        }

        public Vector3 GetPosition()
        {
            return transform.position;
        }
    }
}