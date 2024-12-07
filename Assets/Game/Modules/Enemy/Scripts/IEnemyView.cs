using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IEntityView, IDamageable, ICollidable, IDamageDealer
    {
        public Collider GetCollider();
    }
}