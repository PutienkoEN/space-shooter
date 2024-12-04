using System;
using Cysharp.Threading.Tasks;
using Game.UI.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly GameSceneManager _gameSceneManager;
        private readonly Button _startGameButton;
        private readonly Button _quitGameButton;
        private readonly MainMenuAnimator _mainMenuAnimator;

        [Inject]
        public MainMenuController(
            GameSceneManager gameSceneManager, 
            Button startGameButton, 
            Button quitGameButton, 
            MainMenuAnimator animator)
        {
            _gameSceneManager = gameSceneManager;
            _startGameButton = startGameButton;
            _quitGameButton = quitGameButton;
            _mainMenuAnimator = animator;
        }

        public void Initialize()
        {
            _startGameButton.onClick.AddListener(HandleStartGameClicked);
            _quitGameButton.onClick.AddListener(HandleQuitGameClicked);
        }

        public void Dispose()
        {
            _startGameButton.onClick.RemoveListener(HandleStartGameClicked);
            _quitGameButton.onClick.RemoveListener(HandleQuitGameClicked);
        }
        
        private void HandleStartGameClicked()
        {
            DelaySceneLoad().Forget();
        }
        
        private void HandleQuitGameClicked()
        {
            Application.Quit();
        }
        
        private async UniTask DelaySceneLoad()
        {
            await _mainMenuAnimator.HandleStartGameClicked();
            await _gameSceneManager.LoadGameScene();
        }

    }
}