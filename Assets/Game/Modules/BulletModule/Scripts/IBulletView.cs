using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.BulletModule
{
    public interface IBulletView : IEntityView, ICollidable, IDamageDealer
    {
        public Collider GetCollider();
        public Transform GetTransform();
    }
}