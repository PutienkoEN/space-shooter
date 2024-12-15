using System;
using Game.PickupModule.Scripts;
using SpaceShooter.Game.Enemy;
using Zenject;

namespace SpaceShooter.Game.Level.Events
{
    public class LevelEventHandlerResolver
    {
        private readonly EnemyManager _enemyManager;
        private readonly PickupManager _pickupManager;

        [Inject]
        public LevelEventHandlerResolver(
            EnemyManager enemyManager, 
            PickupManager pickupManager)
        {
            _enemyManager = enemyManager;
            _pickupManager = pickupManager;
        }

        public IGameEventHandler Resolve(ILevelEventData eventData)
        {
            switch (eventData)
            {
                case EnemySpawnLevelEventData data:
                    return new EnemySpawnEventHandler(_enemyManager, data);
                case PickupSpawnLevelEventData data:
                    return new PickupSpawnEventHandler(_pickupManager, data);
                default:
                    throw new ArgumentException(
                        $"There is no handler for this event. Provided handler type: {eventData.GetType()}");
            }
        }
    }
}