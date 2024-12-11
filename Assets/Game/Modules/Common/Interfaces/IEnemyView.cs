using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IEntityView, ICollidable, IDamageDealer, IDamageable
    {
        public void PlayDeathSound();
        public Collider GetCollider();
    }
}