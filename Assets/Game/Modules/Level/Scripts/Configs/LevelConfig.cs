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

        public ILevelData GetData()
        {
            var gameEvents = gameLeveEvents.ConvertAll(gameEvent => gameEvent.GetData());
            return new LevelData(gameEvents);
        }
    }

    public class LevelData : ILevelData
    {
        public List<ILevelEventData> GameLevelEvents { get; }

        public LevelData(List<ILevelEventData> gameLevelEvents)
        {
            GameLevelEvents = gameLevelEvents;
        }
    }
}