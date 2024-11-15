using UnityEngine;

namespace SpaceShooter.Background.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackgroundLayersConfig", menuName = "Configs/NewBackgroundLayersConfig", order = 0)]
    public class BackgroundLayersConfig : ScriptableObject
    {
        public BackgroundData[] configs;
    }
}