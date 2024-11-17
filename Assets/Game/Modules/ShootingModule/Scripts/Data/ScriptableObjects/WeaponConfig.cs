using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        [SerializeField] private GameObject weaponPrefab;
        [SerializeField] private ProjectileConfig projectileConfig;

        public WeaponData GetWeaponData()
        {
            return new WeaponData(
                weaponPrefab,
                projectileConfig);
        }
    }

    public struct WeaponData
    {
        public GameObject WeaponPrefab;
        public ProjectileConfig ProjectileConfig;

        public WeaponData(
            GameObject weaponPrefab, 
            ProjectileConfig projectileConfig)
        {
            WeaponPrefab = weaponPrefab;
            ProjectileConfig = projectileConfig;
        }
    }
    
    public class ProjectileConfig : ScriptableObject
    {
    }
}