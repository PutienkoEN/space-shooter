using System;
using Game.Modules.Common.Scripts;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupView : MonoBehaviour, IPickupView
    {
        public event Action OnPickupTaken;
        
        private Collider _collider;
        
        private void Awake()
        {
            _collider = GetComponentInChildren<Collider>();   
            var colliderHandler = GetComponentInChildren<ChildColliderHandler>();
            if (colliderHandler != null)
            {
                colliderHandler.SetEntityView(this);
            }
        }

        public void HandleTriggerEnter(Collider other)
        {
            var player = other.GetComponentInParent<IPlayerShipView>();
            if (player != null)
            {
                OnPickupTaken?.Invoke();
            }
        }

        public Collider GetCollider()
        {
            if (_collider == null)
            {
                _collider = GetComponentInChildren<Collider>();
            }
            return _collider;
        }
        
        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}