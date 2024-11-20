using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.DebugTools
{
    public class DebugGameSpeedInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container
                .Bind<DebugGameSpeedManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}