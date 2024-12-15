using System;
using Game.Modules.Common.Scripts;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    public sealed class IPickupViewView : MonoBehaviour, IPickupView
    {
        public event Action OnPickupTaken;
        public int MoveSpeed => moveSpeed;
        
        [SerializeField] private int moveSpeed;
        [SerializeField] private PickupItem pickupItem;
        
        private void Awake()
        {
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
        
        public void SetActive(bool value)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}