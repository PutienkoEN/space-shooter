﻿using System.Collections.Generic;
using System.Linq;
using Game.Modules.LevelInterfaces.Scripts;
using SpaceShooter.Game.Level.Events;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelEventManager
    {
        private readonly LevelEventHandlerResolver _levelEventResolver;
        private bool _canSpawnLevel = false;

        [Inject]
        public LevelEventManager(LevelEventHandlerResolver levelEventResolver)
        {
            _levelEventResolver = levelEventResolver;
        }

        public async void StartLevel(ILevelData levelData)
        {
            //ToDO : temp for testing
            if(!_canSpawnLevel)
                return;
            
            var gameEventHandlers = GetHandlers(levelData.GameLevelEvents);
            for (var eventNumber = 0; eventNumber < gameEventHandlers.Count; eventNumber++)
            {
                var gameEventHandler = gameEventHandlers[eventNumber];
                await gameEventHandler.Start();

                // Remove from memory
                gameEventHandlers[eventNumber] = null;
            }
        }

        private List<IGameEventHandler> GetHandlers(List<ILevelEventData> gameLevelEvents)
        {
            return gameLevelEvents
                .ConvertAll(_levelEventResolver.Resolve)
                .ToList();
        }
    }
}