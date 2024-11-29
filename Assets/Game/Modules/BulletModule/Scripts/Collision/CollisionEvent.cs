using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public struct CollisionEvent
    {
        public ColliderObject ColliderObj;
        public IDamagable CollidedWith;

        public CollisionEvent(ColliderObject colliderObj, IDamagable collidedWith)
        {
            ColliderObj = colliderObj;
            CollidedWith = collidedWith;
        }
    }
}