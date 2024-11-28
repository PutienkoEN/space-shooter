using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class LevelEventManager
    {
        private readonly GameLevelEventHandlerResolver _gameLevelEventResolver;

        [Inject]
        public LevelEventManager(GameLevelEventHandlerResolver gameLevelEventResolver)
        {
            _gameLevelEventResolver = gameLevelEventResolver;
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
                .ConvertAll(_gameLevelEventResolver.Resolve)
                .ToList();
        }
    }
}