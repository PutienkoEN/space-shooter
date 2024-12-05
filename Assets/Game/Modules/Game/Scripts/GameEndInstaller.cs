﻿using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.Game
{
    public class GameEndInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container
                .BindInterfacesTo<GameEndObserver>()
                .AsSingle()
                .NonLazy();

            container
                .BindInterfacesTo<PauseGameFinishListener>()
                .AsSingle()
                .NonLazy();
        }
    }
}