using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine.SceneManagement;
using Zenject;

namespace SpaceShooter.Game.SceneManagement
{
    public class GameSceneManager
    {
        private readonly IGameContext _gameContext;

        [Inject]
        public GameSceneManager(IGameContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void LoadGameScene()
        {
            _gameContext.GameStart = true;
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
        }

        public void LoadMenuScene()
        {
            SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Single);
        }
    }
}