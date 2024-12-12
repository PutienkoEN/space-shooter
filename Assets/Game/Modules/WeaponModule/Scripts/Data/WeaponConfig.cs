using Game.Modules.BulletModule;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
    public sealed class WeaponConfig : ScriptableObject
    {
        [Header("Prefabs")] [SerializeField] private WeaponView weaponPrefab;
        [SerializeField] private BulletView projectilePrefab;

        [Header("Configurations")] [SerializeField]
        private int damage;

        [SerializeField] private float fireRate;
        [SerializeField] private float projectileSpeed;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                weaponPrefab,
                projectilePrefab,
                damage,
                fireRate,
                projectileSpeed);
        }
    }

    public struct WeaponData
    {
        public WeaponView WeaponPrefab { get; private set; }
        public BulletView ProjectilePrefab { get; private set; }
        public int Damage { get; private set; }
        public float FireRate { get; private set; }
        public float ProjectileSpeed { get; private set; }

        public WeaponData(
            WeaponView weaponPrefab,
            BulletView projectilePrefab,
            int damage,
            float fireRate,
            float projectileSpeed)
        {
            WeaponPrefab = weaponPrefab;
            ProjectilePrefab = projectilePrefab;
            Damage = damage;
            FireRate = fireRate;
            ProjectileSpeed = projectileSpeed;
        }
    }
}