using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponChanger : MonoBehaviour
    {
        private WeaponController _weaponController;

        [Inject]
        public void Construct(WeaponController weaponController)
        {
            _weaponController = weaponController;
        }
        
        [Button]
        public void SwitchWeapon(WeaponConfig config)
        {
            _weaponController.EquipWeapon(config.GetWeaponData());
        }
    }
}