using System;
using Game.Modules.GameSpeed;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Game
{
    public class PauseGameFinishListener : IGameStartListener, IGameFinishListener, IDisposable
    {
        private readonly IGameSpeedManager _gameSpeedManager;
        private readonly IGameTimeScaleManager _gameTimeScaleManager;

        [Inject]
        public PauseGameFinishListener(
            IGameSpeedManager gameSpeedManager, 
            IGameTimeScaleManager gameTimeScaleManager)
        {
            _gameSpeedManager = gameSpeedManager;
            _gameTimeScaleManager = gameTimeScaleManager;
        }

        public void OnGameStart()
        {
            _gameSpeedManager.SetSlowdown();
        }

        public void OnGameFinish()
        {
            _gameSpeedManager.StopTime();
        }


        public void Dispose()
        {
            _gameTimeScaleManager.ChangeTimeScale(1);
        }
    }
}