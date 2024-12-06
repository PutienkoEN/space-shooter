﻿using Game.Modules.LevelInterfaces.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelGameStartListener : IGameStartListener
    {
        private readonly LevelEventManager _levelEventManager;
        private readonly ILevelProvider _levelProvider;

        [Inject]
        public LevelGameStartListener(LevelEventManager levelEventManager, ILevelProvider levelProvider)
        {
            _levelEventManager = levelEventManager;
            _levelProvider = levelProvider;
        }

        public void OnGameStart()
        {
            var levelConfig = _levelProvider.GetLevelConfig();
            _levelEventManager.StartLevel(levelConfig.GetData());
        }
    }
}