using System;
using Effects.Explosion;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectAnimatorInstaller : GameModuleInstaller
    {
        [SerializeField] private EffectsAnimator.Settings settings;
        
        public override void Install(DiContainer container)
        {
            container.Bind<EffectsAnimator.Settings>()
                .FromInstance(settings)
                .AsSingle();
           
            container.Bind<EffectsAnimator>()
                .AsSingle()
                .NonLazy();
            
        }
    }
}