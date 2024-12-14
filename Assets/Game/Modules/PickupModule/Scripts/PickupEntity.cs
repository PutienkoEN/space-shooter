using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public class PickupEntity : IEntity
    {
        public event Action<bool> OnInGameStateChanged;
        public void Update(float deltaTime)
        {
            Debug.Log("pickup is ticking");
        }
    }
}