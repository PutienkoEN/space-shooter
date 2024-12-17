using System;
using Cysharp.Threading.Tasks;
using Game.Modules.MainMenu.Scripts;
using Game.UI.Scripts;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.SceneManagement;
using UnityEngine;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly MainMenuView _mainMenuView;
        private readonly MainMenuAnimator _mainMenuAnimator;
        
        private readonly GameSceneManager _gameSceneManager;
        private readonly LevelManager _levelManager;

        public MainMenuController(
            MainMenuView mainMenuView,
            MainMenuAnimator mainMenuAnimator,
            GameSceneManager gameSceneManager,
            LevelManager levelManager)
        {
            _mainMenuView = mainMenuView;
            _mainMenuAnimator = mainMenuAnimator;
            _gameSceneManager = gameSceneManager;
            _levelManager = levelManager;
        }

        public void Initialize()
        {
            _mainMenuView.ContinueButton.onClick.AddListener(HandleContinueButtonClicked);
            _mainMenuView.StartButton.onClick.AddListener(HandleStartGameClicked);
            _mainMenuView.ExitButton.onClick.AddListener(HandleQuitGameClicked);

            var shouldToggleContinue = !_levelManager.IsFirstLevel();
            _mainMenuView.ToggleContinueButton(shouldToggleContinue);
        }

        public void Dispose()
        {
            _mainMenuView.ContinueButton.onClick.RemoveListener(HandleContinueButtonClicked);
            _mainMenuView.StartButton.onClick.RemoveListener(HandleStartGameClicked);
            _mainMenuView.ExitButton.onClick.RemoveListener(HandleQuitGameClicked);
        }

        private void HandleContinueButtonClicked()
        {
            DelaySceneLoad().Forget();
        }

        private void HandleStartGameClicked()
        {
            _levelManager.FirstLevel();
            DelaySceneLoad().Forget();
        }

        private void HandleQuitGameClicked()
        {
            Application.Quit();
        }

        private async UniTask DelaySceneLoad()
        {
            await _mainMenuAnimator.HandleStartGameClicked();
            _gameSceneManager.LoadGameScene();
        }
    }
}