using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public class PickupItemProcessor
    {
        private readonly Dictionary<Type, IPickupStrategy> _pickupStrategies = new();

        public PickupItemProcessor(WeaponPickupStrategy weaponPickupStrategy)
        {
            RegisterStrategy<WeaponPickupConfig>(weaponPickupStrategy);
        }

        private void RegisterStrategy<T>(IPickupStrategy strategy) where T : IPickupConfig
        {
            _pickupStrategies[typeof(T)] = strategy;
        }
        
        public void ProcessPickupItem(IPickupConfig config)
        {
            var configType = config.GetType();
            
            if (_pickupStrategies.TryGetValue(configType, out var handler))
            {
                handler.ProcessPickup(config.GetPickupData());
            }
            else
            {
                Debug.LogWarning($"No handler registered for pickup config type: {configType}");
            }
        }
    }
}