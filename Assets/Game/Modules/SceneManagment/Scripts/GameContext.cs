using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    public class GameContext : IGameContext
    {
        [Inject]
        public GameContext(bool gameStart)
        {
            GameStart = gameStart;
        }

        public bool GameStart { get; set; }
    }
}