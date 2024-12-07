using Effects.Explosion;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.AnimationModule.Scripts
{
    public sealed class EffectAnimatorInstaller : GameModuleInstaller
    {
        [SerializeField] private Effect _enemyDeathEffect;
        
        public override void Install(DiContainer container)
        {
            container.Bind<EffectsAnimator>().AsSingle().WithArguments(_enemyDeathEffect);
        }
    }
}