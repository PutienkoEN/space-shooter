using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponChanger : MonoBehaviour
    {
        private WeaponComponent _weaponComponent;

        private void Construct(WeaponComponent weaponComponent)
        {
            _weaponComponent = weaponComponent;
        }
        
        public void SwitchWeapon(WeaponConfig config)
        {
            _weaponComponent.EquipWeapon(config.GetWeaponData());
        }
    }
}