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
        [SerializeField] private Effect pickupEffect;
        
        public override void Install(DiContainer container)
        {
            if (enemyDeathEffect == null)
            {
                throw new ArgumentNullException(nameof(enemyDeathEffect));
            }
            
            if (pickupEffect == null)
            {
                throw new ArgumentNullException(nameof(pickupEffect));
            }
            
            container.Bind<EffectsAnimator>()
                .AsSingle()
                .WithArguments(enableEffects, enemyDeathEffect, pickupEffect)
                .NonLazy();
            
          
            
        }
    }
}