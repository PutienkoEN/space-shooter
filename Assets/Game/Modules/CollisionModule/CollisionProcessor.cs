using System;
using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class CollisionProcessor : IGameTickable
    {
        public IReadOnlyDictionary<int, ICollisionEvent> NewEvents => _newEvents;
        private readonly Dictionary<int, ICollisionEvent> _newEvents = new();
        private readonly List<int> _processedEvents = new();

        public void AddCollisionEvent(ICollisionEvent collisionEvent)
        {
            var id = collisionEvent.GetEventKey();
            if (_newEvents.ContainsKey(id))
                return;
            _newEvents.Add(id, collisionEvent);
        }

        public void Tick(float deltaTime)
        {
            foreach (var eventPair in _newEvents)
            {
                var collisionEvent = eventPair.Value;
                
                collisionEvent.Apply();
                
                _processedEvents.Add(eventPair.Key);
            }

            foreach (var key in _processedEvents)
            {
                _newEvents.Remove(key);
                Debug.Log("removed processed Event");
            }
            _processedEvents.Clear();
        }
    }
}