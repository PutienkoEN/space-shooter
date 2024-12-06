using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public class EffectsAnimator
    {
        private readonly ParticleSystem _enemyDeathEffect;

        public EffectsAnimator(ParticleSystem enemyDeathEffect)
        {
            _enemyDeathEffect = enemyDeathEffect;
        }

        public void PlayExplosion(Transform transform, Action callback)
        {
            if (_enemyDeathEffect == null)
            {
                callback();
                return;
            }
            
            ParticleSystem instance =  UnityEngine.Object.Instantiate(
                _enemyDeathEffect, 
                transform.position, 
                transform.rotation);
            float duration = instance.main.duration;
            Delay(duration, callback).Forget();
        }

        private async UniTaskVoid Delay(float duration, Action callback)
        {
            await UniTask.WaitForSeconds(duration);
            callback();
        }
    }
}