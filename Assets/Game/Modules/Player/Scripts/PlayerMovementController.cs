using System;
using SpaceShooter.Game.CameraUtility;
using SpaceShooter.Game.Components;
using SpaceShooter.Game.Input;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerMovementController : IInitializable, IDisposable
    {
        private readonly MoveComponent _moveComponent;
        private readonly ColliderComponent _colliderComponent;

        private readonly ITouchInputMovementHandler _touchInputMovementHandler;
        private readonly WorldCoordinates _worldCoordinates;

        [Inject]
        public PlayerMovementController(
            MoveComponent moveComponent,
            ColliderComponent colliderComponent,
            ITouchInputMovementHandler touchInputMovementHandler,
            WorldCoordinates worldCoordinates)
        {
            _moveComponent = moveComponent;
            _colliderComponent = colliderComponent;
            _touchInputMovementHandler = touchInputMovementHandler;
            _worldCoordinates = worldCoordinates;
        }

        public void Initialize()
        {
            _touchInputMovementHandler.OnPositionChange += MovePlayerToCoordinates;
        }

        public void Dispose()
        {
            _touchInputMovementHandler.OnPositionChange -= MovePlayerToCoordinates;
        }

        private void MovePlayerToCoordinates(Vector2 target)
        {
            var newPosition = GetNewPosition(target);
            var newPositionClamped = ClampPosition(newPosition);

            _moveComponent.Move(newPositionClamped);
        }

        private Vector2 GetNewPosition(Vector2 targetWorldPosition)
        {
            var currentPosition = _moveComponent.GetPosition();

            var newPositionX = currentPosition.x + targetWorldPosition.x;
            var newPositionY = currentPosition.y + targetWorldPosition.y;

            return new Vector2(newPositionX, newPositionY);
        }

        private Vector3 ClampPosition(Vector2 newPosition)
        {
            var size = _colliderComponent.GetSize();
            return _worldCoordinates.ClampToScreen(newPosition, size.x, size.y);
        }
    }
}