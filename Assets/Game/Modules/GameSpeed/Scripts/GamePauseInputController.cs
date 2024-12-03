using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using SpaceShooter.Game.GameSpeed;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Game.Modules.GameSpeed.Scripts
{
    public class GamePauseInputController : IInitializable, IDisposable, ITickable
    {
        private readonly IGameManager _gameManager;
        private readonly Button _pauseButton;
        private readonly IGameSpeedManager _speedManager;
        
        private GameState _gameState;

        [Inject]
        public GamePauseInputController(
            IGameManager gameManager, 
            Button pauseButton, 
            IGameSpeedManager speedManager)
        {
            _gameManager = gameManager;
            _pauseButton = pauseButton;
            _speedManager = speedManager;
            Debug.Log("Game Pause Input Controller created");
            
        }

        // private bool _buttonInputProcessed;
        private bool _normalSpeedTriggered;
        private bool _slowDownTriggered;

        private CancellationTokenSource _cancellationToken = new();

        private void HandleNormalSpeed()
        {
            Debug.Log("HandleNormalSpeed");
            if (_gameManager.State == GameState.PAUSE)
                return;
            _normalSpeedTriggered = true;
            ProcessNormalSpeed();
        }

        private void HandleSlowDown()
        {
            Debug.Log("HandleSlowDown");
            _slowDownTriggered = true;
            _cancellationToken?.Cancel();
            ProcessSlowDown();
        }

        private void TogglePause()
        {
            Debug.Log("Game Pause Input");
            if (_gameManager.State == GameState.PAUSE)
            {
                _gameManager.ResumeGame();
            }
            else
            {
                _gameManager.PauseGame();
            }
        }
        
        public void Tick()
        {
            // if (_normalSpeedTriggered)
            // {
            //     Debug.Log("normal speed is triggered");
            //     _normalSpeedTriggered = false;
            //     ProcessNormalSpeed();
            // }
            // else if (_slowDownTriggered)
            // {
            //     Debug.Log("slow speed is triggered");
            //     _slowDownTriggered = false;
            //     _cancellationToken?.Cancel();
            //     ProcessSlowDown();
            // }
        }

        private void ProcessNormalSpeed()
        {
            _cancellationToken?.Cancel();
            _cancellationToken = new CancellationTokenSource();
            Wait(_cancellationToken.Token).Forget();
        }

        private void ProcessSlowDown()
        {
            TogglePauseButton(true);

        }
        
        private async UniTask Wait(CancellationToken token)
        {
            Debug.Log("waiting");
            await UniTask.DelayFrame(5, cancellationToken: token);
            Debug.Log("finished waiting");
            if (!token.IsCancellationRequested)
            {
                Debug.Log("should switch off");
                TogglePauseButton(false);
            }
        }
        
        public void Initialize()
        {
            _pauseButton.onClick.AddListener(TogglePause);
            _speedManager.OnSlowDown += HandleSlowDown;
            _speedManager.OnNormalSpeed += HandleNormalSpeed;
            Debug.Log("GamePauseInputController initialized");
        }

        public void Dispose()
        {
            _pauseButton.onClick.RemoveListener(TogglePause);
        }
        
        private void TogglePauseButton(bool value)
        {
            _pauseButton.gameObject.SetActive(value);
        }

        
    }
}