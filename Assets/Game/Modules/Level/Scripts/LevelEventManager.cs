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
            foreach (var gameEventHandler in gameEventHandlers)
            {
                await gameEventHandler.Start();
            }
        }

        private List<IGameEventHandler> GetHandlers(List<IGameLevelEventData> gameLevelEvents)
        {
            return gameLevelEvents
                .ConvertAll(_levelEventResolver.Resolve)
                .ToList();
        }
    }
}