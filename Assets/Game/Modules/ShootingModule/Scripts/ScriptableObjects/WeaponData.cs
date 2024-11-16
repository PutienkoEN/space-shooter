using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "SpaceShooter/ShootingModule/WeaponConfig", order = 0)]
    public class WeaponData : ScriptableObject
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private Transform[] projectileSource;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private float projectileSpeed;
        [SerializeField] private float fireRate;
    }
}