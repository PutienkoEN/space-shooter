namespace Game.Modules.Enemy.Scripts
{
    public class PickupSpawnGameLevelEventConfig : IGameLevelEventConfig<PickupSpawnGameLevelEventData>
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