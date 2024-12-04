using System;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.GameSpeed
{
    public class GamePauseController : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        private readonly IGameSpeedManager _gameSpeedManager;

        [Inject]
        public GamePauseController(IGameManager gameManager, IGameSpeedManager gameSpeedManager)
        {
            _gameManager = gameManager;
            _gameSpeedManager = gameSpeedManager;
        }

        public void Initialize()
        {
            _gameManager.OnGamePause += _gameSpeedManager.StopTime;
            _gameManager.OnGameResume += _gameSpeedManager.ResumeTime;
        }

        public void Dispose()
        {
            _gameManager.OnGamePause -= _gameSpeedManager.StopTime;
            _gameManager.OnGameResume -= _gameSpeedManager.ResumeTime;
        }
    }
}