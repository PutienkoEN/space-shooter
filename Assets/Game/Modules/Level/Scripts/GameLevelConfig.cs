using System.Collections.Generic;
using GSpaceShooter.Game.Level.Events;
using SpaceShooter.Game.Level.Events;
using UnityEngine;

namespace SpaceShooter.Game.Level
{
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/Configuration")]
    public class GameLevelConfig : ScriptableObject
    {
        [SerializeReference] private List<ILevelEventConfig<IGameLevelEventData>> gameLeveEvents = new();

        public GameLevelData GetData()
        {
            var gameEvents = gameLeveEvents.ConvertAll(gameEvent => gameEvent.GetData());
            return new GameLevelData(gameEvents);
        }
    }

    public class GameLevelData
    {
        public List<IGameLevelEventData> GameLevelEvents { get; private set; }

        public GameLevelData(List<IGameLevelEventData> gameLevelEvents)
        {
            GameLevelEvents = gameLevelEvents;
        }
    }
}