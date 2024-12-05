using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public class EffectsAnimator
    {
        private ParticleSystem _enemyDeathEffect;

        public EffectsAnimator(ParticleSystem enemyDeathEffect)
        {
            _enemyDeathEffect = enemyDeathEffect;
        }

        public void PlayExplosion(Transform transform, Action callback)
        {
            UnityEngine.Object.Instantiate(_enemyDeathEffect, transform.position, transform.rotation);
            Delay(callback).Forget();
        }

        private async UniTaskVoid Delay(Action callback)
        {
            await UniTask.WaitForSeconds(1);
            callback();
        }
    }
}