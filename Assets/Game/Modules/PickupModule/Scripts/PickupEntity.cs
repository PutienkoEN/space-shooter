using System;
using Game.Modules.AnimationModule.Scripts;
using Game.Modules.BulletModule.Scripts;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.PickupModule.Scripts
{
    public sealed class PickupEntity : IPickupEntity
    {
        public event Action<bool> OnInGameStateChanged;
        public event Action<IPickupEntity> OnDestroy;
        
        private readonly IPickupConfigData _pickupData;
        private readonly IPickupView _pickupView;
        private readonly MoveComponent _moveComponent;
        private readonly PickupItemProcessor _pickupItemProcessor;
        private readonly BoundsCheckComponent _boundsCheckComponent;
        private readonly EffectsAnimator _effectsAnimator;

        private bool _IsActive;
        private bool _isInGame;

        [Inject]
        public PickupEntity(
            MoveComponent moveComponent, 
            IPickupConfigData pickupData,
            IPickupView pickupView, 
            PickupItemProcessor pickupItemProcessor, 
            BoundsCheckComponent boundsCheckComponent, 
            EffectsAnimator effectsAnimator)
        {
            _moveComponent = moveComponent;
            _pickupData = pickupData;
            _pickupView = pickupView;
            _pickupItemProcessor = pickupItemProcessor;
            _boundsCheckComponent = boundsCheckComponent;
            _effectsAnimator = effectsAnimator;
            
            _pickupView.OnPickupTaken += HandlePickupTaken;

            _IsActive = true;
        }

        private void HandlePickupTaken()
        {
            _pickupItemProcessor.ProcessPickupItem(_pickupData);
            _pickupView.SetActive(false);
            _IsActive = false;
            _effectsAnimator.PlayPickup(_pickupView.GetCollider().transform, Destroy);
        }

        public void OnUpdate(float deltaTime)
        {
            if(!_IsActive)
                return;
            _moveComponent.MoveToDirection(Vector3.down, deltaTime);
            _boundsCheckComponent.IsInGame(
                _pickupView.GetCollider(), 
                SetIsInGame,
                Destroy);
        }
        
        
        private void SetIsInGame(bool value)
        {
            if (_isInGame == value)
            {
                return;
            }
            _isInGame = value;
            OnInGameStateChanged?.Invoke(value);
        }

        public void Destroy()
        {
            _pickupView.OnPickupTaken -= HandlePickupTaken;
            
            OnDestroy?.Invoke(this);
            
           _pickupView.Dispose();
        }
    }
}