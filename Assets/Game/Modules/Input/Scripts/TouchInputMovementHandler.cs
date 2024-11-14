using System;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Input
{
    public sealed class TouchInputMovementHandler : ITouchInputMovementHandler, IInitializable, IDisposable
    {
        public event Action<Vector2> OnPositionChange;

        private readonly ITouchInputHandler _touchInputHandler;

        private bool _isMoveStarted;
        private Vector2 _previousPosition = Vector2.negativeInfinity;

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

        private void InitializeMovement(Vector2 touchPosition)
        {
            _previousPosition = touchPosition;
            _isMoveStarted = true;
        }

        private void StopMovement()
        {
            _isMoveStarted = false;
            _previousPosition = Vector2.negativeInfinity;
        }

        private void Move(Vector2 touchPosition)
        {
            if (!_isMoveStarted)
            {
                return;
            }

            var vectorToMove = GetVectorToMove(touchPosition);
            _previousPosition = touchPosition;

            OnPositionChange?.Invoke(vectorToMove);
        }

        private Vector2 GetVectorToMove(Vector2 touchPosition)
        {
            var vectorXPosition = touchPosition.x - _previousPosition.x;
            var vectorYPosition = touchPosition.y - _previousPosition.y;

            return new Vector2(vectorXPosition, vectorYPosition);
        }
    }
}