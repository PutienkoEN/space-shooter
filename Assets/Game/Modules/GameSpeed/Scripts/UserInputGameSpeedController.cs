using System;
using Game.Modules.GameSpeed;
using SpaceShooter.Game.Input;
using Zenject;
using Vector2 = UnityEngine.Vector2;

namespace Game.Modules
{
    public class UserInputGameSpeedController : IInitializable, IDisposable
    {
        private readonly IGameSpeedManager _gameSpeedManager;
        private readonly ITouchInputHandler _touchInputHandler;

        public UserInputGameSpeedController(IGameSpeedManager gameSpeedManager, ITouchInputHandler touchInputHandler)
        {
            _gameSpeedManager = gameSpeedManager;
            _touchInputHandler = touchInputHandler;
        }

        public void Initialize()
        {
            _touchInputHandler.OnTouchFinished += StartSlowDown;
            _touchInputHandler.OnTouchStarted += StopSlowdown;
        }

        public void Dispose()
        {
            _touchInputHandler.OnTouchFinished -= StartSlowDown;
            _touchInputHandler.OnTouchStarted -= StopSlowdown;
        }

        private void StartSlowDown()
        {
            _gameSpeedManager.StartSlowdown();
        }

        private void StopSlowdown(Vector2 _)
        {
            _gameSpeedManager.StopSlowdown();
        }
    }
}