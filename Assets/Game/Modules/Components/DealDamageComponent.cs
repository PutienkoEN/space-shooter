using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class DealDamageComponent
    {
        private readonly CollisionProcessor _collisionProcessor;

        public DealDamageComponent(CollisionProcessor collisionProcessor)
        {
            _collisionProcessor = collisionProcessor;
        }
        
        public bool TryDealDamage(Collider otherObject, int layer, int damage)
        {
            if(otherObject.gameObject.TryGetComponent(out IDamagable damagable))
            {
                Debug.Log("found damagable");
                ColliderObject colliderObject = new ColliderObject(layer, damage);
                ICollisionEvent collisionEvent = new DealDamageEvent(colliderObject, damagable);
                _collisionProcessor.AddCollisionEvent(collisionEvent);
                return true;
            }
            return false;
        }
    }
}