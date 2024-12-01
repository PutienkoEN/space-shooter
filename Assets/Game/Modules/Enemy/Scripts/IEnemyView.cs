using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView
    {
        public Collider GetCollider();
        public void Destroy();
    }
}