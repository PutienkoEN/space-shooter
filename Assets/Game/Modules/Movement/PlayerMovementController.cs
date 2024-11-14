using System;
using SpaceShooter.Input;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Movement
{
    public class PlayerMovementController : IInitializable, IDisposable
    {
        private readonly MoveComponent _moveComponent;
        private readonly ColliderComponent _colliderComponent;

        private readonly ITouchInputMovementHandler _touchInputMovementHandler;
        private readonly WorldUtility _worldUtility;

        [Inject]
        public PlayerMovementController(
            MoveComponent moveComponent,
            ColliderComponent colliderComponent,
            ITouchInputMovementHandler touchInputMovementHandler,
            WorldUtility worldUtility)
        {
            _moveComponent = moveComponent;
            _colliderComponent = colliderComponent;
            _touchInputMovementHandler = touchInputMovementHandler;
            _worldUtility = worldUtility;
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
            var currentPosition = _colliderComponent.GetPosition();

            var newPositionX = currentPosition.x + targetWorldPosition.x;
            var newPositionY = currentPosition.y + targetWorldPosition.y;

            return new Vector2(newPositionX, newPositionY);
        }

        private Vector3 ClampPosition(Vector2 newPosition)
        {
            var size = _colliderComponent.GetSize();
            return _worldUtility.ClampToScreen(newPosition, size.x, size.y);
        }
    }
}