using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class LevelManagerInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container
                .Bind<GameLevelEventHandlerResolver>()
                .AsSingle();

            container
                .Bind<LevelEventManager>()
                .AsSingle();

            container
                .Bind<DebugLevelManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}