using System;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class GameLevelEventHandlerResolver
    {
        private readonly EnemyManager _enemyManager;

        [Inject]
        public GameLevelEventHandlerResolver(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public IGameEventHandler Resolve(IGameLevelEventData eventData)
        {
            switch (eventData)
            {
                case EnemySpawnGameLevelEventData data:
                    return new EnemySpawnEventHandler(_enemyManager, data);
                case PickupSpawnGameLevelEventData:
                    throw new NotImplementedException(
                        $"There is no handler for {typeof(PickupSpawnGameLevelEventData)}");
                default:
                    throw new ArgumentException(
                        $"There is no handler for this event. Provided handler type: {eventData.GetType()}");
            }
        }
    }
}