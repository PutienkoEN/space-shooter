using System;
using Game.Modules.Scores;
using Game.Modules.UImodule;
using SpaceShooter.Game.Level;
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
        private readonly LevelManager _levelManager;

        public EndGamePopupController(
            EndGamePopupView endGamePopupView,
            GameSceneManager sceneManager,
            ScoreManager scoreManager,
            LevelManager levelManager)
        {
            _endGamePopupView = endGamePopupView;
            _sceneManager = sceneManager;
            _scoreManager = scoreManager;
            _levelManager = levelManager;
        }

        public void Initialize()
        {
            _endGamePopupView.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _endGamePopupView.ExitButton.onClick.AddListener(OnMainMenuButtonClicked);
            _endGamePopupView.NextLevelButton.onClick.AddListener(NextLevelButtonClicked);
        }

        public void Dispose()
        {
            _endGamePopupView.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _endGamePopupView.ExitButton.onClick.RemoveListener(OnMainMenuButtonClicked);
            _endGamePopupView.NextLevelButton.onClick.RemoveListener(NextLevelButtonClicked);
        }

        public void OnGameFinish()
        {
            UpdateScoreText();
            UpdateNextLevelButton();
            _endGamePopupView.SetActive(true);
        }

        private void UpdateNextLevelButton()
        {
            var hasNextLevel = _levelManager.HasNextLevel();
            _endGamePopupView.ToggleNextLevelButton(hasNextLevel);
        }

        private void UpdateScoreText()
        {
            var score = _scoreManager.GetScore();
            _endGamePopupView.SetScore(score.ToString());
        }

        private void OnMainMenuButtonClicked()
        {
            _sceneManager.LoadMenuScene();
        }

        private void OnRestartButtonClicked()
        {
            _sceneManager.LoadGameScene();
        }

        private void NextLevelButtonClicked()
        {
            var nextLevel = _levelManager.NextLevel();
            if (nextLevel)
            {
                _sceneManager.LoadGameScene();
            }
        }
    }
}