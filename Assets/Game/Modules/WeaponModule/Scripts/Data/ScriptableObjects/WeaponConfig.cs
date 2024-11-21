using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "SpaceShooter/ShootingModule/WeaponData", order = 0)]
    public sealed class WeaponConfig : ScriptableObject
    {
        [SerializeField] private WeaponView prefab;
        [SerializeField] private int damage;
        [SerializeField] private float fireRate;
        [SerializeField] private ProjectileConfig projectileConfig;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                prefab,
                damage,
                fireRate,
                projectileConfig);
        }
    }

    public struct WeaponData
    {
        public WeaponView Prefab;
        public int Damage;
        public float FireRate;
        public IProjectileConfig ProjectileConfig;

        public WeaponData(
            WeaponView prefab,
            int damage,
            float fireRate,
            IProjectileConfig projectileConfig)
        {
            Damage = damage;
            ProjectileConfig = projectileConfig;
            FireRate = fireRate;
            Prefab = prefab;
        }
    }
}