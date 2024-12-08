using Cysharp.Threading.Tasks;
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

        public async UniTask LoadGameScene()
        {
            _gameContext.GameStart = true;
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);
        }
    }
}