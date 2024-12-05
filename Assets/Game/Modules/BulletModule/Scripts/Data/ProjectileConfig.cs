using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ProjectileConfig", menuName = "SpaceShooter/ShootingModule/ProjectileConfig", order = 0)]
    public sealed class ProjectileConfig : ScriptableObject, IProjectileConfig
    {
        [SerializeField] private float projectileSpeed;

        public ProjectileData GetProjectileData()
        {
            return new ProjectileData()
            {
                ProjectileSpeed = projectileSpeed
            };
        }
    }

    public struct ProjectileData
    {
        public float ProjectileSpeed;

        public ProjectileData(
            GameObject projectilePrefab, 
            float projectileSpeed)
        {
            ProjectileSpeed = projectileSpeed;
        }
    }
}