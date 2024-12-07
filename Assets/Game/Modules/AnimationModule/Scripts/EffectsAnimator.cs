using System;
using Cysharp.Threading.Tasks;
using Effects.Explosion;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectsAnimator
    {
        private readonly IEffect _enemyDeathEffect;

        public EffectsAnimator(IEffect enemyDeathEffect)
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
            
            //Can be later replaced with a Factory and Pool
            IEffect effect = _enemyDeathEffect.Instantiate(transform.position, transform.rotation);
            float duration = effect.GetDuration();
            Delay(effect, duration, callback).Forget();
        }

        private async UniTaskVoid Delay(IEffect instance, float duration, Action callback)
        {
            await UniTask.WaitForSeconds(duration);
            instance.Destroy();
            callback();
        }
    }
}