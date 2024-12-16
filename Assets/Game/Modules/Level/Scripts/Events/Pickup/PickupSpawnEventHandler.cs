using System.Threading;
using Cysharp.Threading.Tasks;
using Game.PickupModule.Scripts;

namespace SpaceShooter.Game.Level.Events
{
    public class PickupSpawnEventHandler : IGameEventHandler
    {
        private readonly PickupSpawnLevelEventData _pickupSpawnData;
        private readonly PickupManager _pickupManager;

        public PickupSpawnEventHandler(
            PickupManager pickupManager,
            PickupSpawnLevelEventData pickupSpawnData)
        {
            _pickupSpawnData = pickupSpawnData;
            _pickupManager = pickupManager;
        }

        public async UniTask Start(CancellationToken cancellationToken)
        {
            SpawnPickup(_pickupSpawnData.PickupCreateData);
            await UniTask.CompletedTask;
        }

        private void SpawnPickup(PickupCreateData pickupCreateData)
        {
            _pickupManager.CreatePickupItem(pickupCreateData);
            
        }
    }
}