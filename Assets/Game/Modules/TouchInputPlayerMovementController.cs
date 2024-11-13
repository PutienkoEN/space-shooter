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

        private void InitializeMovement(Vector2 touchPosition)
        {
            var touchWorldPosition = _worldUtility.ToWorldPositionWithoutZ(touchPosition);
            var playerWorldPosition = _player.transform.position;

            var xOffsetWorldPosition = touchWorldPosition.x - playerWorldPosition.x;
            var yOffsetWorldPosition = touchWorldPosition.y - playerWorldPosition.y;

            _deltaBetweenInitialPositionInput = new Vector2(xOffsetWorldPosition, yOffsetWorldPosition);
        }

        private void StopMovement()
        {
            _deltaBetweenInitialPositionInput = Vector2.negativeInfinity;
        }

        private void MovePlayer(Vector2 touchPosition)
        {
            if (_deltaBetweenInitialPositionInput.Equals(Vector2.negativeInfinity))
            {
                return;
            }

            var touchWorldPosition = _worldUtility.ToWorldPositionWithoutZ(touchPosition);
            var targetWorldPositionWithOffset = GetTargetPositionWithOffset(touchWorldPosition);

            MovePlayerToCoordinates(targetWorldPositionWithOffset);
        }

        private Vector2 GetTargetPositionWithOffset(Vector3 playerInputWorldPosition)
        {
            var newPlayerPositionX = playerInputWorldPosition.x - _deltaBetweenInitialPositionInput.x;
            var newPlayerPositionY = playerInputWorldPosition.y - _deltaBetweenInitialPositionInput.y;

            return new Vector2(newPlayerPositionX, newPlayerPositionY);
        }

        private void MovePlayerToCoordinates(Vector2 targetWorldPosition)
        {
            var playerSizes = _player.GetSize();
            var clampedTargetWorldPosition =
                _worldUtility.ClampPosition(targetWorldPosition, playerSizes.x, playerSizes.y);

            _player.Move(clampedTargetWorldPosition);
        }
    }
}