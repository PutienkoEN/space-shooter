using System;
using Game.Modules.UImodule;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.MainMenu.Scripts
{
    public sealed class EndGamePopupController : IInitializable, IDisposable, IGameFinishListener
    {
        private readonly EndGamePopupView _endGamePopupView;
        private const string MAIN_MENU_SCENE = "MenuScene"; //ToDo : Will be used when FinishGame is fixed;
        
        public EndGamePopupController(EndGamePopupView endGamePopupView)
        {
            _endGamePopupView = endGamePopupView;
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
            // SceneManager.LoadScene(MAIN_MENU_SCENE, LoadSceneMode.Single); //ToDo : Will be used when FinishGame is fixed;
            Debug.Log("OnMainMenuButtonClicked");
        }

        private void OnRestartButtonClicked()
        {
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name); //ToDo : Will be used when FinishGame is fixed;
            Debug.Log("OnRestartButtonClicked");
        }
    }
}