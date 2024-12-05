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
            Delay(callback).Forget();
        }

        private async UniTaskVoid Delay(Action callback)
        {
            await UniTask.WaitForSeconds(1);
            callback();
        }
    }
}