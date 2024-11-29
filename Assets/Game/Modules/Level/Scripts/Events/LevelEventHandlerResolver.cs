using System;
using SpaceShooter.Game.Enemy;
using Zenject;

namespace SpaceShooter.Game.Level.Events
{
    public class LevelEventHandlerResolver
    {
        private readonly EnemyManager _enemyManager;

        [Inject]
        public LevelEventHandlerResolver(EnemyManager enemyManager)
        {
            _enemyManager = enemyManager;
        }

        public IGameEventHandler Resolve(IGameLevelEventData eventData)
        {
            switch (eventData)
            {
                case EnemySpawnLevelEventData data:
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