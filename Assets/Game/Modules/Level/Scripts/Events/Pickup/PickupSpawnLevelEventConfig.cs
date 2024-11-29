using GSpaceShooter.Game.Level.Events;

namespace SpaceShooter.Game.Level.Events
{
    public class PickupSpawnLevelEventConfig : ILevelEventConfig<PickupSpawnGameLevelEventData>
    {
        public PickupSpawnGameLevelEventData GetData()
        {
            return new PickupSpawnGameLevelEventData();
        }
    }

    public class PickupSpawnGameLevelEventData : IGameLevelEventData
    {
    }
}