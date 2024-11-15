using System;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponent : MonoBehaviour
    {
        public bool canShoot;
        public GameObject defaultWeapon;
        public Weapon activeWeapon;
        public Transform weaponsParent;

        public bool CanShoot => canShoot;
        
        void Awake()
        {
            if(defaultWeapon == null)
            {
                Debug.LogError("Specify default weapon");
            }
            else
            {
                Weapon weapon = Instantiate(defaultWeapon, this.transform).GetComponent<Weapon>();
                EquipWeapon(weapon);
            }
        }

        public void EquipWeapon(Weapon weapon)
        {
            weapon.transform.SetParent(weaponsParent, false);
            activeWeapon = weapon;
        }
        
        public void SetIsFiring(bool value)
        {
            activeWeapon.isFiring = value;
        }

        public void Update()
        {
            SetIsFiring(canShoot);
            activeWeapon.Fire();
        }
    }
}