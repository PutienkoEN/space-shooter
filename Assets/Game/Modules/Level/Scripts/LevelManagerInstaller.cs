using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class LevelManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private GameLevelConfig levelConfig;

        public override void Install(DiContainer container)
        {
            container
                .Bind<LevelManager>()
                .AsSingle();

            container
                .Bind<GameLevelData>()
                .FromInstance(levelConfig.GetData())
                .AsSingle();

            container
                .Bind<DebugLevelManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}