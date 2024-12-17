using System;
using SpaceShooter.Game.Player;

namespace Game.PickupModule.Scripts
{
    public sealed class WeaponPickupStrategy : IPickupStrategy
    {
        private readonly PlayerManager _playerManager;

        public WeaponPickupStrategy(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        public Type GetConfigType()
        {
            return typeof(WeaponPickupConfigData);
        }

        public void ProcessPickup(IPickupConfigData pickupData)
        {
            if (pickupData is WeaponPickupConfigData weaponData)
            {
                var player = _playerManager.GetPlayer();
                if (player != null)
                {
                    player.ChangeWeapon(weaponData.WeaponData);
                }
            }
        }
    }
}