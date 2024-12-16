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
        
        public void ProcessPickupItem(IPickupConfigData data)
        {
            Type dataType = data.GetType();
            
            if (_pickupStrategies.TryGetValue(dataType, out var handler))
            {
                handler.ProcessPickup(data);
            }
            else
            {
                Debug.LogWarning($"No handler registered for pickup config type: {dataType}");
            }
        }
    }
}