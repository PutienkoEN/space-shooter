using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Effects.Explosion;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectsAnimator
    {
        private readonly IEffect _enemyDeathEffect;
        private bool _enableEffects;
        private CancellationTokenSource _cancellationTokenSource = new();

        public EffectsAnimator(
            bool enableEffects,
            IEffect enemyDeathEffect
            )
        {
            _enableEffects = enableEffects;
            _enemyDeathEffect = enemyDeathEffect;
            if (_enemyDeathEffect == null)
            {
                Debug.LogError("No enemy death effect set on EffectAnimator");
            }
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
            // IEffect effect = _enemyDeathEffect.Instantiate(transform.position, transform.rotation);
           
        }
    }
}