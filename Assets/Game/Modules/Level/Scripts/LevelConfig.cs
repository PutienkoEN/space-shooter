using System.Collections.Generic;
using Game.Modules.LevelInterfaces.Scripts;
using GSpaceShooter.Game.Level.Events;
using SpaceShooter.Game.Level.Events;
using UnityEngine;

namespace SpaceShooter.Game.Level
{
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/Configuration")]
    public class LevelConfig : ScriptableObject, ILevelConfig
    {
        [SerializeReference] private List<ILevelEventConfig<ILevelEventData>> gameLeveEvents = new();

        public GameLevelData GetData()
        {
            var gameEvents = gameLeveEvents.ConvertAll(gameEvent => gameEvent.GetData());
            return new GameLevelData(gameEvents);
        }
    }

    public class GameLevelData
    {
        public List<ILevelEventData> GameLevelEvents { get; private set; }

        public GameLevelData(List<ILevelEventData> gameLevelEvents)
        {
            GameLevelEvents = gameLevelEvents;
        }
    }
}