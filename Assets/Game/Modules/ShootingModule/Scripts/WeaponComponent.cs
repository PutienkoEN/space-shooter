using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponent : MonoBehaviour
    {
        [SerializeField] private bool canShoot;
        public GameObject defaultWeapon;
        public Transform gunsParent;

        public bool CanShoot => canShoot;
        public Weapon activeWeapon { get; private set; }
        
        void Awake()
        {
            if(defaultWeapon == null)
            {
                Debug.LogError("Specify default weapon");
            }
            else
            {
                GameObject weapon = Instantiate(defaultWeapon, this.transform);
                // activeWeapon = weapon;
                // EquipWeapon(weapon);
            }
        }

        // public void EquipWeapon(Weapon weapon)
        // {
        //     //Debug.Log($"{this.name} active weapon : " + activeWeapon);
        //     //Debug.Log("weapon : " + weapon);
        //     if(activeWeapon.uniqueID != weapon.uniqueID)
        //     {
        //         Destroy(activeWeapon.gameObject);
        //     }
        //     weapon.gameObject.transform.SetParent(gunsParent, false);
        //     activeWeapon = weapon;
        //     activeWeapon.SetupWeaponManager(this);
        //     activeWeapon.Initialize();
        //     activeWeapon.gameObject.SetActive(true);
        // }

        private int GetUniqueID()
        {
            int uniqueID = 0;
            int numOfAttempts = 0;
            // do
            // {
            //     uniqueID = UnityEngine.Random.Range(0, 100);
            //     numOfAttempts++;
            //     if(numOfAttempts >= 100)
            //     {
            //         return uniqueID;
            //     }
            // }
            // while (weaponIDs.Contains(uniqueID));
            return uniqueID;

        }

        public GameObject CustomInstantiate(GameObject weaponPrefab, Transform parent)
        {
            GameObject newWeapon = Instantiate(weaponPrefab, parent);
            return newWeapon;
        }

        public void SetCanShoot(bool value)
        {
            canShoot = value;
        }
    }

    public class Weapon
    {
    }
}