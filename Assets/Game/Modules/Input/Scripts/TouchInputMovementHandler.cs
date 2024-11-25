using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Input
{
    public sealed class TouchInputMovementHandler : ITouchInputMovementHandler, IInitializable, IDisposable
    {
        public event Action<Vector3> OnPositionChange;

        private readonly ITouchInputHandler _touchInputHandler;

        private bool _isMoveStarted;
        private Vector3 _previousPosition = Vector3.negativeInfinity;

        public TouchInputMovementHandler(ITouchInputHandler touchInputHandler)
        {
            _touchInputHandler = touchInputHandler;
        }

        public void Initialize()
        {
            _touchInputHandler.OnTouchStarted += InitializeMovement;
            _touchInputHandler.OnTouchFinished += StopMovement;
            _touchInputHandler.OnTouchPositionChange += Move;
        }

        public void Dispose()
        {
            _touchInputHandler.OnTouchStarted -= InitializeMovement;
            _touchInputHandler.OnTouchFinished -= StopMovement;
            _touchInputHandler.OnTouchPositionChange -= Move;
        }

        private void InitializeMovement(Vector3 touchPosition)
        {
            _previousPosition = touchPosition;
            _isMoveStarted = true;
        }

        private void StopMovement()
        {
            _isMoveStarted = false;
            _previousPosition = Vector3.negativeInfinity;
        }

        private void Move(Vector3 touchPosition)
        {
            if (!_isMoveStarted)
            {
                return;
            }

            var vectorToMove = GetVectorToMove(touchPosition);
            _previousPosition = touchPosition;

            OnPositionChange?.Invoke(vectorToMove);
        }

        private Vector3 GetVectorToMove(Vector3 touchPosition)
        {
            var vectorXPosition = touchPosition.x - _previousPosition.x;
            var vectorYPosition = touchPosition.y - _previousPosition.y;

            return new Vector3(vectorXPosition, vectorYPosition);
        }
    }
}