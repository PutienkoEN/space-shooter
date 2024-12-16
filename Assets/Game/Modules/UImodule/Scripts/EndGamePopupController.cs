using System;
using Game.Modules.Scores;
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
        private readonly ScoreManager _scoreManager;

        public EndGamePopupController(
            EndGamePopupView endGamePopupView,
            GameSceneManager sceneManager,
            ScoreManager scoreManager)
        {
            _endGamePopupView = endGamePopupView;
            _sceneManager = sceneManager;
            _scoreManager = scoreManager;
        }

        public void OnGameFinish()
        {
            UpdateScoreText();
            _endGamePopupView.SetActive(true);
        }

        private void UpdateScoreText()
        {
            var score = _scoreManager.GetScore();
            _endGamePopupView.SetScore(score.ToString());
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