using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private WeaponView prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int damage;
        [SerializeField] private ProjectileConfig projectileConfig;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                prefab.firePoints,
                parent,
                damage,
                projectileConfig);
        }
    }

    public struct WeaponData
    {
        public Transform[] FirePoints;
        public Transform Parent;
        public int Damage;
        public IProjectileConfig ProjectileConfig;

        public WeaponData(
            Transform[] firePoints,
            Transform parent,
            int damage,
            IProjectileConfig projectileConfig)
        {
            FirePoints = firePoints;
            Parent = parent;
            Damage = damage;
            ProjectileConfig = projectileConfig;
        }
    }
    
    public class ProjectileConfig : ScriptableObject, IProjectileConfig
    {
    }

    public interface IProjectileConfig
    {
    }
}