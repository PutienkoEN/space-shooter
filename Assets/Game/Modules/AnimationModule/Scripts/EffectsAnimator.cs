using System;
using System.Threading;
using Effects.Explosion;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectsAnimator
    {
        private readonly IEffect _enemyDeathEffect;
        private readonly IEffect _pickupEffect;
        private bool _enableEffects;
        private CancellationTokenSource _cancellationTokenSource = new();

        public EffectsAnimator(
            bool enableEffects,
            IEffect enemyDeathEffect, 
            IEffect pickupEffect)
        {
            _enableEffects = enableEffects;
            _enemyDeathEffect = enemyDeathEffect;
            _pickupEffect = pickupEffect;
        }

        public void PlayExplosion(Transform transform, Action callback)
        {
            
            if (!_enableEffects)
            {
                callback();
                return;
            }
            
            //Can be later replaced with a Factory and Pool
            _enemyDeathEffect.Play(
                transform.position, 
                transform.rotation, 
                callback, 
                _cancellationTokenSource.Token);
        }
        
        public void PlayPickup(Transform transform, Action callback)
        {
            
            if (!_enableEffects)
            {
                callback();
                return;
            }
            
            //Can be later replaced with a Factory and Pool
            _pickupEffect.Play(
                transform.position, 
                transform.rotation, 
                callback, 
                _cancellationTokenSource.Token);
        }
    }
}