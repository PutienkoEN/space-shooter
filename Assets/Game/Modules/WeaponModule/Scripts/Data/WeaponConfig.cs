using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
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
                projectileConfig.GetProjectileData());
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