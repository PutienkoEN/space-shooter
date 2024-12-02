using System;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.GameSpeed.Scripts
{
    public class GamePauseInputController : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        private readonly Button _pauseButton;

        [Inject]
        public GamePauseInputController(IGameManager gameManager, Button pauseButton)
        {
            _gameManager = gameManager;
            _pauseButton = pauseButton;
        }

        public void Initialize()
        {
            _pauseButton.onClick.AddListener(TogglePause);
        }

        public void Dispose()
        {
            _pauseButton.onClick.RemoveListener(TogglePause);
        }

        private void TogglePause()
        {
            if (_gameManager.State == GameState.PAUSE)
            {
                _gameManager.ResumeGame();
            }
            else
            {
                _gameManager.PauseGame();
            }
        }
    }
}