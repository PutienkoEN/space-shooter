using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.PickupModule.Scripts
{
    [CreateAssetMenu(fileName = "PickupConfig", menuName = "SpaceShooter/PickupModule/PickupConfig", order = 0)]
    public sealed class WeaponPickupConfig : PickupConfig
    {
        [SerializeField] private WeaponConfig weaponConfig;

        public override IPickupConfigData GetPickupData()
        {
            return new WeaponPickupConfigData(
                weaponConfig);
        }
    }
    
    public struct WeaponPickupConfigData : IPickupConfigData
    {
        public WeaponData WeaponData { get; private set; }

        public WeaponPickupConfigData(WeaponConfig weaponConfig)
        {
            WeaponData = weaponConfig.GetData();
        }
        
    }
    
    public class HealthPickupConfig : PickupConfig
    {
        [SerializeField] private int health;
        public override IPickupConfigData GetPickupData()
        {
            return new HealthData(
                health);
        }
    }

    public struct HealthData : IPickupConfigData
    {
        public HealthData(int health)
        {
            Health = health;
        }

        public int Health { get; private set; }
    }
}