using System;
using Game.Modules.UImodule;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.SceneManagement;
using Zenject;

namespace Game.Modules.MainMenu.Scripts
{
    public sealed class EndGamePopupController : IInitializable, IDisposable, IGameFinishListener
    {
        private readonly EndGamePopupView _endGamePopupView;
        private readonly GameSceneManager _sceneManager;
        
        public EndGamePopupController(
            EndGamePopupView endGamePopupView, 
            GameSceneManager sceneManager)
        {
            _endGamePopupView = endGamePopupView;
            _sceneManager = sceneManager;
        }

        public void OnGameFinish()
        {
            _endGamePopupView.SetActive(true);
        }

        public void Initialize()
        {
            _endGamePopupView.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _endGamePopupView.ExitButton.onClick.AddListener(OnMainMenuButtonClicked);
        }
        
        public void Dispose()
        {
            _endGamePopupView.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _endGamePopupView.ExitButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }
        
        private void OnMainMenuButtonClicked()
        {
            _sceneManager.LoadMenuScene();
        }

        private void OnRestartButtonClicked()
        {
            _sceneManager.LoadGameScene();
        }
    }
}