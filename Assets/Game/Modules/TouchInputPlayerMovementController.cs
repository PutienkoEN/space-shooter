using System;
using UnityEngine;
using Zenject;

namespace Input
{
    /*
     * Controller used to handle player movement based on provided input.
     */
    public sealed class TouchInputPlayerMovementController : IInitializable, IDisposable
    {
        private readonly Character _player;
        private readonly TouchInputHandler _touchInputHandler;
        private readonly WorldUtility _worldUtility;

        /*
         * This value required so we can move our player relative to input.
         * This means even if we click in the center of the screen, and player on the bottom,
         * we still be able to move our player.
         */
        private Vector2 _deltaBetweenInitialPositionInput = Vector2.negativeInfinity;

        public TouchInputPlayerMovementController(
            Character player,
            TouchInputHandler touchInputHandler,
            WorldUtility worldUtility)
        {
            _player = player;
            _touchInputHandler = touchInputHandler;
            _worldUtility = worldUtility;
        }

        public void Initialize()
        {
            _touchInputHandler.OnTouchStarted += InitializeMovement;
            _touchInputHandler.OnTouchFinished += StopMovement;

            _touchInputHandler.OnTouchPositionChange += MovePlayer;
        }

        public void Dispose()
        {
            _touchInputHandler.OnTouchStarted -= InitializeMovement;
            _touchInputHandler.OnTouchFinished -= StopMovement;

            _touchInputHandler.OnTouchPositionChange -= MovePlayer;
        }

        private void InitializeMovement(Vector2 playerInput)
        {
            var playerInputWorldPosition = _worldUtility.ToWorldPositionWithoutZ(playerInput);

            var playerPosition = _player.transform.position;
            var positionWithOffsetX = playerInputWorldPosition.x - playerPosition.x;
            var positionWithOffsetY = playerInputWorldPosition.y - playerPosition.y;

            _deltaBetweenInitialPositionInput = new Vector2(positionWithOffsetX, positionWithOffsetY);
        }

        private void StopMovement()
        {
            _deltaBetweenInitialPositionInput = Vector2.negativeInfinity;
        }

        private void MovePlayer(Vector2 targetPosition)
        {
            if (_deltaBetweenInitialPositionInput.Equals(Vector2.negativeInfinity))
            {
                return;
            }

            var targetWorldPosition = _worldUtility.ToWorldPositionWithoutZ(targetPosition);
            var targetWithOffset = GetTargetPositionWithOffset(targetWorldPosition);
            var targetClamped = _worldUtility.ClampPosition(targetWithOffset);

            _player.Move(targetClamped);
        }

        private Vector2 GetTargetPositionWithOffset(Vector3 playerInputWorldPosition)
        {
            var newPlayerPositionX = playerInputWorldPosition.x - _deltaBetweenInitialPositionInput.x;
            var newPlayerPositionY = playerInputWorldPosition.y - _deltaBetweenInitialPositionInput.y;

            return new Vector2(newPlayerPositionX, newPlayerPositionY);
        }
    }
}