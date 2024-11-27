using System.Collections.Generic;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;

namespace Game.Modules.Background.Scripts.Data
{
    [CreateAssetMenu(fileName = "BackgroundLayersConfig", menuName = "SpaceShooter/Background/BackgroundLayersConfig", order = 0)]
    public class BackgroundLayersConfig : ScriptableObject
    {
        [SerializeField] private BackgroundConfig[] backgroundLayers;

        public IReadOnlyList<BackgroundData> GetBackgroundLayersData()
        {
            List<BackgroundData> backgroundDataList = new();
            foreach (BackgroundConfig backgroundLayer in backgroundLayers)
            {
                backgroundDataList.Add(backgroundLayer.GetBackgroundData());
            }

            return backgroundDataList.AsReadOnly();
        }
    }
}