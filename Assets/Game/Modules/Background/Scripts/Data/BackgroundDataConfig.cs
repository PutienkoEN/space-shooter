using UnityEngine;

namespace SpaceShooter.Background.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackgroundDataConfig", menuName = "SpaceShooter/Background/BackgroundDataConfig", order = 0)]
    public class BackgroundDataConfig : ScriptableObject
    {
        public BackgroundData[] configs;
    }
}