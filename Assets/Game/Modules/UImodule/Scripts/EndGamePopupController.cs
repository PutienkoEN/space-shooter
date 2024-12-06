using System;
using Game.Modules.UImodule;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.MainMenu.Scripts
{
    public class EndGamePopupController : IInitializable, IDisposable, IGameFinishListener
    {
        private EndGamePopupView _view;
        private readonly IGameManager _gameManager;

        private const string MAIN_MENU_SCENE = "MenuScene";
        
        public EndGamePopupController(EndGamePopupView view, IGameManager gameManager)
        {
            _view = view;
            _gameManager = gameManager;
        }

        public void OnGameFinish()
        {
            _view.SetActive(true);
        }

        public void Initialize()
        {
            _view.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _view.ExitButton.onClick.AddListener(OnMainMenuButtonClicked);
        }
        
        public void Dispose()
        {
            _view.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _view.ExitButton.onClick.RemoveListener(OnMainMenuButtonClicked);
        }
        
        private void OnMainMenuButtonClicked()
        {
            // _gameManager.FinishGame();
            // SceneManager.LoadScene(MAIN_MENU_SCENE, LoadSceneMode.Single);
            Debug.Log("OnMainMenuButtonClicked");
        }

        private void OnRestartButtonClicked()
        {
            // _gameManager.FinishGame();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("OnRestartButtonClicked");
        }
    }
}