using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Movement
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

        public void Move(Vector3 target)
        {
            var moveTowards = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            transform.position = moveTowards;
        }
    }
}