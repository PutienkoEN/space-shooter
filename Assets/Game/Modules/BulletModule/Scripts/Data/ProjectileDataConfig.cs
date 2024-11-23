using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ProjectileData", menuName = "SpaceShooter/ShootingModule/ProjectileData", order = 0)]
    public sealed class ProjectileDataConfig : ScriptableObject, IProjectileDataConfig
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float projectileSpeed;

        public ProjectileData GetProjectileData()
        {
            return new ProjectileData()
            {
                ProjectilePrefab = projectilePrefab,
                ProjectileSpeed = projectileSpeed
            };
        }
    }

    public struct ProjectileData
    {
        public GameObject ProjectilePrefab;
        public float ProjectileSpeed;

        public ProjectileData(
            GameObject projectilePrefab, 
            float projectileSpeed)
        {
            ProjectilePrefab = projectilePrefab;
            ProjectileSpeed = projectileSpeed;
        }
    }
}