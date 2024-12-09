using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView : IDamageable, ICollidable, IDisposable
    {
        public event Action<IDamageable> OnDealDamage;
        public Collider GetCollider();
        public void PlayDeathSound();
    }
}