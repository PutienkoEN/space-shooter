using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "SpaceShooter/ShootingModule/WeaponData", order = 0)]
    public sealed class WeaponDataConfig : ScriptableObject
    {
        [SerializeField] private WeaponView prefab;
        [SerializeField] private int damage;
        [SerializeField] private float fireRate;
        [SerializeField] private ProjectileDataConfig projectileDataDataConfig;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                prefab,
                damage,
                fireRate,
                projectileDataDataConfig.GetProjectileData());
        }
    }

    public struct WeaponData
    {
        public WeaponView Prefab;
        public int Damage;
        public float FireRate;
        public ProjectileData ProjectileData;
        
        public WeaponData(
            WeaponView prefab,
            int damage,
            float fireRate,
            ProjectileData projectileData)
        {
            Damage = damage;
            ProjectileData = projectileData;
            FireRate = fireRate;
            Prefab = prefab;
        }
    }
}