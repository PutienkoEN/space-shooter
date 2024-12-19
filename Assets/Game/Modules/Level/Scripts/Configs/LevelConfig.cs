using System.Collections.Generic;
using Game.Modules.LevelInterfaces.Scripts;
using GSpaceShooter.Game.Level.Events;
using SpaceShooter.Game.Level.Events;
using UnityEngine;

namespace SpaceShooter.Game.Level
{
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/LevelConfiguration")]
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        [SerializeReference] private List<ILevelEventConfig<ILevelEventData>> gameLeveEvents = new();

        public ILevelConfigData GetData()
        {
            var gameEvents = gameLeveEvents.ConvertAll(gameEvent => gameEvent.GetData());
            return new LevelConfigConfigData(gameEvents);
        }
    }

    public class LevelConfigConfigData : ILevelConfigData
    {
        public List<ILevelEventData> GameLevelEvents { get; }

        public LevelConfigConfigData(List<ILevelEventData> gameLevelEvents)
        {
            GameLevelEvents = gameLevelEvents;
        }
    }
}