using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.GameSpeed.Scripts
{
    public class GamePauseInputController : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        private readonly IButton _pauseButton;
        private readonly IGameSpeedManager _speedManager;
        
        private CancellationTokenSource _cancellationToken = new();

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

        private void HandleNormalSpeed()
        {
            if (_gameManager.State == GameState.PAUSE)
                return;
            ProcessNormalSpeed();
        }

        private void HandleSlowDown()
        {
            //Cancel Waiting started in ProcessNormalSpeed
            CancelPendingActions();
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

        private void ProcessNormalSpeed()
        {
            CancelPendingActions();
            WaitAndTogglePauseButton().Forget();
        }
        
        private void CancelPendingActions()
        {
            _cancellationToken?.Cancel();
            _cancellationToken = new CancellationTokenSource();
        }
        
        private async UniTask WaitAndTogglePauseButton()
        {
            //NormalSpeed(touch down) event comes first. Then comes SlowDown(touch up) event.
            //And only after that button click is processed.
            //Delay for 5 frames to check if SlowDown event comes. If not, then hide Button.
            await UniTask.DelayFrame(5, cancellationToken: _cancellationToken.Token);
            if (!_cancellationToken.Token.IsCancellationRequested)
            {
                TogglePauseButton(false);
            }
        }
        
        private void TogglePauseButton(bool value)
        {
            _pauseButton.SetActive(value);
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
    }
}