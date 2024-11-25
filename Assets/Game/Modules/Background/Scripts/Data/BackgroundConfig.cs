using UnityEngine;

namespace SpaceShooter.Background.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackgroundConfig", menuName = "SpaceShooter/Background/BackgroundConfig", order = 0)]
    public class BackgroundConfig : ScriptableObject
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