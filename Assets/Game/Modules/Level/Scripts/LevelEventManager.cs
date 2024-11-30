using System.Collections.Generic;
using System.Linq;
using SpaceShooter.Game.Level.Events;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class LevelEventManager
    {
        private readonly LevelEventHandlerResolver _levelEventResolver;

        [Inject]
        public LevelEventManager(LevelEventHandlerResolver levelEventResolver)
        {
            _levelEventResolver = levelEventResolver;
        }

        public async void StartLevel(GameLevelData gameLevelData)
        {
            var gameEventHandlers = GetHandlers(gameLevelData.GameLevelEvents);
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