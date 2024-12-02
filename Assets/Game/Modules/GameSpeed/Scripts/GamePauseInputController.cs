using System;
using SpaceShooter.Game.GameSpeed;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.GameSpeed.Scripts
{
    public class GamePauseInputController : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        private readonly Button _pauseButton;
        private IGameSpeedManager _speedManager;

        [Inject]
        public GamePauseInputController(IGameManager gameManager, Button pauseButton, IGameSpeedManager speedManager)
        {
            _gameManager = gameManager;
            _pauseButton = pauseButton;
            _speedManager = speedManager;

            _speedManager.OnSlowDown += HandleSlowDown;
            _speedManager.OnNormalSpeed += HandleNormalSpeed;
        }

        private void HandleNormalSpeed()
        {
            _pauseButton.gameObject.SetActive(false);
        }

        private void HandleSlowDown()
        {
            _pauseButton.gameObject.SetActive(true);
            _pauseButton.interactable = true;
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