using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IDamageable
    {
        public Collider GetCollider();
        public void Destroy();
    }
}