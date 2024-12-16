using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupItemProcessor
    {
        
        private readonly Dictionary<Type, IPickupStrategy> _pickupStrategies = new();

        public PickupItemProcessor(List<IPickupStrategy> pickupStrategies)
        {
            foreach (IPickupStrategy pickupStrategy in pickupStrategies)
            {
                RegisterStrategy(pickupStrategy);
            }
        }

        private void RegisterStrategy(IPickupStrategy strategy)
        {
            Type configType = strategy.GetConfigType();
            if (_pickupStrategies.ContainsKey(configType))
            {
                return;
            }
            _pickupStrategies[configType] = strategy;
        }
        
        public void ProcessPickupItem(IPickupConfig config)
        {
            Type configType = config.GetType();
            
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