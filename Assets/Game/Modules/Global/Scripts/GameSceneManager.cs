using SpaceShooter.Game.Level;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class GameSceneManager
    {
        private readonly GameContext _gameContext;
        private readonly GameLevelConfig _initialLevelConfig;

        [Inject]
        public GameSceneManager(GameContext gameContext, GameLevelConfig initialLevelConfig)
        {
            _gameContext = gameContext;
            _initialLevelConfig = initialLevelConfig;
        }

        public void LoadGameScene()
        {
            _gameContext.CurrentLevel = _initialLevelConfig;
            SceneManager.LoadScene("GameScene");
        }
    }
}