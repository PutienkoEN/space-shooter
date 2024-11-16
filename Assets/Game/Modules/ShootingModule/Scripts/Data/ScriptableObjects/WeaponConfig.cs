using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private GameObject weaponPrefab;
        // [SerializeField] private Transform[] projectileSource;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float fireRate;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                targetLayer,
                weaponPrefab,
                bulletPrefab,
                projectileSpeed,
                fireRate);
        }
    }

    public struct WeaponData
    {
        public LayerMask TargetLayer;
        public GameObject WeaponPrefab;
        public GameObject BulletPrefab;
        public float ProjectileSpeed;
        public float FireRate;

        public WeaponData(
            LayerMask targetLayer, 
            GameObject weaponPrefab, 
            GameObject bulletPrefab, 
            float projectileSpeed, 
            float fireRate)
        {
            TargetLayer = targetLayer;
            WeaponPrefab = weaponPrefab;
            BulletPrefab = bulletPrefab;
            ProjectileSpeed = projectileSpeed;
            FireRate = fireRate;
        }
    }
}