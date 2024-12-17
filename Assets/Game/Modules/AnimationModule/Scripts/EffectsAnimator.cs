using System;
using System.Threading;
using Effects.Explosion;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectsAnimator
    {
        private readonly Settings _settings;
        private CancellationTokenSource _cancellationTokenSource = new();

        public EffectsAnimator(Settings settings)
        {
            _settings = settings;
        }

        public void PlayExplosion(Transform transform, Action callback)
        {
            PlayEffect(_settings.EnemyDeathEffect, transform, callback);
        }
        
        public void PlayPickup(Transform transform, Action callback)
        {
            PlayEffect(_settings.PickupEffect, transform, callback);
        }

        private void PlayEffect(IEffect effect, Transform transform, Action callback)
        {
            if (!_settings.enableEffects)
            {
                callback();
                return;
            }

            //Can be later replaced with a Factory and Pool
            effect.Play(
                transform.position, 
                transform.rotation, 
                callback, 
                _cancellationTokenSource.Token);
        }

        [Serializable]
        public class Settings
        {
            public bool enableEffects = true;
            [SerializeField] private Effect enemyDeathEffect;
            [SerializeField] private Effect pickupEffect;

            public IEffect EnemyDeathEffect => enemyDeathEffect;
            public IEffect PickupEffect => pickupEffect;
        }
    }

    
}