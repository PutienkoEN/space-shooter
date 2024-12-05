using System;
using System.Collections.Generic;
using System.Linq;
using Game.Modules.LevelInterfaces.Scripts;
using ModestTree;
using SpaceShooter.Game.Level.Events;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelEventManager
    {
        public event Action<bool> OnLevelEventChange;

        private readonly LevelEventHandlerResolver _levelEventResolver;

        [Inject]
        public LevelEventManager(LevelEventHandlerResolver levelEventResolver)
        {
            _levelEventResolver = levelEventResolver;
        }

        public async void StartLevel(ILevelData levelData)
        {
            var gameEventHandlers = GetHandlers(levelData.GameLevelEvents);

            var hasEvents = !gameEventHandlers.IsEmpty();
            OnLevelEventChange?.Invoke(hasEvents);

            for (var eventNumber = 0; eventNumber < gameEventHandlers.Count; eventNumber++)
            {
                var gameEventHandler = gameEventHandlers[eventNumber];
                await gameEventHandler.Start();

                // Remove from memory
                gameEventHandlers[eventNumber] = null;
            }

            OnLevelEventChange?.Invoke(false);
        }

        private List<IGameEventHandler> GetHandlers(List<ILevelEventData> gameLevelEvents)
        {
            return gameLevelEvents
                .ConvertAll(_levelEventResolver.Resolve)
                .ToList();
        }
    }
}