using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IDamagable
    {
        public Collider GetCollider();
        public void Destroy();
    }
}