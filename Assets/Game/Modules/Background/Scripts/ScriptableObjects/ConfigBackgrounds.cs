using UnityEngine;
using UnityEngine.Serialization;

namespace SpaceShooter.Background.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackgroundConfig", menuName = "Configs/NewBackgroundConfig", order = 0)]
    public class ConfigBackgrounds : ScriptableObject
    {
        public Background.BackgroundConfig[] configs;
    }
}