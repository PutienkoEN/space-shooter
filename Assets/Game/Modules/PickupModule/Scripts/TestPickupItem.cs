using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.PickupModule.Scripts
{
    public class TestPickupItem : PickupItem
    {
        [SerializeField] private WeaponConfig weaponConfig;
    }
}