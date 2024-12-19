using System.Collections.Generic;
using Game.Modules.LevelInterfaces.Scripts;
using UnityEngine;

namespace SpaceShooter.Game.Level
{
    /// <summary>
    /// This class represent levels that are available to the player through game.
    /// This allows to create order of levels (which will be first to be played, which second etc.).
    /// </summary>
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/LevelConfigurationList")]
    public class LevelConfigList : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> levelConfigs;

        public LevelConfigListData GetData()
        {
            var levelData = levelConfigs.ConvertAll(levelConfig => levelConfig.GetData());
            return new LevelConfigListData(levelData);
        }
    }

    public struct LevelConfigListData
    {
        public List<ILevelConfigData> LevelConfigData { get; private set; }

        public LevelConfigListData(List<ILevelConfigData> levelConfigData)
        {
            LevelConfigData = levelConfigData;
        }
    }
}