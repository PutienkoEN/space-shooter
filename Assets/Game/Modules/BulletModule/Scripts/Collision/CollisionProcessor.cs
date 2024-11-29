using System;
using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class CollisionProcessor : IGameTickable
    {
        private readonly Dictionary<int, CollisionEvent> _newEvents = new();
        private readonly List<int> _processedEvents = new();
        private readonly CollisionConditions _conditions;

        public CollisionProcessor(CollisionConditions conditions)
        {
            _conditions = conditions;
        }

        public void AddCollisionEvent(CollisionEvent collisionEvent)
        {
            var id = GetEventKey(collisionEvent);
            _newEvents.Add(id, collisionEvent);
            Debug.Log("added CollisionEvent");
        }

        public void Tick(float deltaTime)
        {
            foreach (var eventPair in _newEvents)
            {
                Debug.Log("go through events list");
                var collisionEvent = eventPair.Value;
                if (collisionEvent.CollidedWith != null)
                {
                    if (_conditions.IsTrue(
                            collisionEvent.ColliderObj.Layer, 
                            collisionEvent.CollidedWith.GetLayer()))
                    {
                        collisionEvent.CollidedWith.InvokeOnDamage(collisionEvent.ColliderObj.Damage);
                        Debug.Log("deal damage : " + collisionEvent.ColliderObj.Damage);
                    }
                }
                _processedEvents.Add(eventPair.Key);
            }

            foreach (var key in _processedEvents)
            {
                _newEvents.Remove(key);
                Debug.Log("removed processed Event");
            }
            _processedEvents.Clear();
        }
        
        private int GetEventKey(CollisionEvent collisionEvent)
        {
            // Generate a unique key for the event based on its collider pair
            return HashCode.Combine(collisionEvent.ColliderObj.GetHashCode(), 
                collisionEvent.CollidedWith.GetHashCode());
        }
    }
}