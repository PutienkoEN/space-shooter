using System;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.GameSpeed.Scripts
{
    public class GamePauseInputController : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        private readonly IButton _pauseButton;
        private readonly IGameSpeedManager _speedManager;

        [Inject]
        public GamePauseInputController(
            IGameManager gameManager, 
            IButton pauseButton, 
            IGameSpeedManager speedManager)
        {
            _gameManager = gameManager;
            _pauseButton = pauseButton;
            _speedManager = speedManager;
        }
        
        public void Initialize()
        {
            _pauseButton.OnClick += TogglePause;
            _speedManager.OnSlowDown += HandleSlowDown;
            _speedManager.OnNormalSpeed += HandleNormalSpeed;
        }

        public void Dispose()
        {
            _pauseButton.OnClick += TogglePause;
            _speedManager.OnSlowDown -= HandleSlowDown;
            _speedManager.OnNormalSpeed -= HandleNormalSpeed;
        }

        private void HandleNormalSpeed()
        {
            TogglePauseButton(false);
        }

        private void HandleSlowDown()
        {
            TogglePauseButton(true);
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
        
        private void TogglePauseButton(bool value)
        {
            _pauseButton.SetActive(value);
        }
    }
}