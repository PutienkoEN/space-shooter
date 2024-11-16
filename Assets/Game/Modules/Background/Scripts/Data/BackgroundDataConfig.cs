using UnityEngine;

namespace SpaceShooter.Background.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackgroundDataConfig", menuName = "SpaceShooter/Background/BackgroundDataConfig", order = 0)]
    public class BackgroundDataConfig : ScriptableObject
    {
        [SerializeField] private float speed;
        [SerializeField] private int zDistance;
        [SerializeField] private Material material;
        [SerializeField] private GameObject prefab;

        public BackgroundData GetBackgroundData()
        {
            return new BackgroundData(speed, zDistance, material, prefab);
        }
    }
}