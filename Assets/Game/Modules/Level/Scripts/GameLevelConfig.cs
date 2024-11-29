using System.Collections.Generic;
using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    [CreateAssetMenu(
        fileName = "LevelConfiguration",
        menuName = "SpaceShooter/Level/Configuration")]
    public class GameLevelConfig : ScriptableObject
    {
        [SerializeReference] private List<IGameLevelEventConfig<IGameLevelEventData>> gameLeveEvents = new();

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