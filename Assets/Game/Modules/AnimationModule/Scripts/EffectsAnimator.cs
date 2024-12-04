using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Game.Modules.AnimationModule.Scripts
{
    public class EffectsAnimator
    {

        public EffectsAnimator()
        {
            
        }

        public void PlayExplosion(Action callback)
        {
            Delay().Forget();
            callback();
        }

        private async UniTaskVoid Delay()
        {
            await UniTask.Delay(1);
        }
    }
}