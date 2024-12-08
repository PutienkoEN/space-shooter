using System;
using Effects.Explosion;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectAnimatorInstaller : GameModuleInstaller
    {
        [SerializeField] private bool enableEffects = true;
        [SerializeField] private Effect enemyDeathEffect;
        
        public override void Install(DiContainer container)
        {
            if (enemyDeathEffect == null)
            {
                throw new ArgumentNullException(nameof(enemyDeathEffect));
            }
            
            container.Bind<EffectsAnimator>()
                .AsSingle()
                .WithArguments(enableEffects, enemyDeathEffect)
                .NonLazy();
        }
    }
}