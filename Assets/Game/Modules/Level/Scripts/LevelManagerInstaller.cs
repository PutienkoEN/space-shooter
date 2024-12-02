using SpaceShooter.Game.Level.Events;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelManagerInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container
                .Bind<LevelEventHandlerResolver>()
                .AsSingle();

            container
                .Bind<LevelEventManager>()
                .AsSingle();

            container
                .Bind<DebugLevelManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            container
                .BindInterfacesAndSelfTo<LevelGameStartListener>()
                .AsSingle()
                .NonLazy();
        }
    }
}