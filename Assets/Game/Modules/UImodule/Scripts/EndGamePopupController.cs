using System;
using Game.Modules.Game;
using Game.Modules.Scores;
using Game.Modules.UImodule;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.SceneManagement;
using UnityEngine;
using Zenject;

namespace Game.Modules.MainMenu.Scripts
{
    public sealed class EndGamePopupController : IInitializable, IDisposable, IGameFinishListener
    {
        private readonly EndGamePopupView _endGamePopupView;

        private readonly GameSceneManager _sceneManager;
        private readonly ScoreManager _scoreManager;
        private readonly LevelManager _levelManager;

        private readonly LevelProgressContext _levelProgressContext;

        public EndGamePopupController(
            EndGamePopupView endGamePopupView,
            GameSceneManager sceneManager,
            ScoreManager scoreManager,
            LevelManager levelManager,
            LevelProgressContext levelProgressContext)
        {
            _endGamePopupView = endGamePopupView;
            _sceneManager = sceneManager;
            _scoreManager = scoreManager;
            _levelManager = levelManager;
            _levelProgressContext = levelProgressContext;
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
            var showNextLevelButton = ShouldShowNextLevelButton();
            _endGamePopupView.ToggleNextLevelButton(showNextLevelButton);
        }

        private bool ShouldShowNextLevelButton()
        {
            return _levelProgressContext.IsLevelSuccess() && _levelManager.HasNextLevel();
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
            else
            {
                Debug.LogWarning("There is no next level.");
            }
        }
    }
}