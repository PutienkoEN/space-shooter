using GSpaceShooter.Game.Level.Events;

namespace SpaceShooter.Game.Level.Events
{
    public class PickupSpawnLevelEventConfig : ILevelEventConfig<PickupSpawnLevelEventData>
    {
        public PickupSpawnLevelEventData GetData()
        {
            return new PickupSpawnLevelEventData();
        }
    }

    public class PickupSpawnLevelEventData : ILevelEventData
    {
    }
}