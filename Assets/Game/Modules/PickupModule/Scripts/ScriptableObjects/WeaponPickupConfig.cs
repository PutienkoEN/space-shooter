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
    
    public class WeaponPickupConfigData : IPickupConfigData
    {
        public WeaponConfig WeaponConfig { get; private set; }

        public WeaponPickupConfigData(WeaponConfig weaponConfig)
        {
            WeaponConfig = weaponConfig;
        }
        
    }
    

}