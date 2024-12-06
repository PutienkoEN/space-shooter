using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.AnimationModule.Scripts
{
    public class EffectAnimatorInstaller : GameModuleInstaller
    {
        [SerializeField] private ParticleSystem _enemyDeathEffect;
        public override void Install(DiContainer container)
        {
            container.Bind<EffectsAnimator>().AsSingle().WithArguments(_enemyDeathEffect);
        }
    }
}