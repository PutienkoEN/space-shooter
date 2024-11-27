using System;
using SpaceShooter.Game.CameraUtility;
using SpaceShooter.Game.Components;
using SpaceShooter.Game.Input;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerMoveController : IInitializable, IDisposable
    {
        private readonly MoveComponent _moveComponent;
        private readonly ColliderComponent _colliderComponent;

        private readonly ITouchInputMovementHandler _touchInputMovementHandler;
        private readonly WorldCoordinates _worldCoordinates;

        private Vector3 _targetPosition;

        [Inject]
        public PlayerMoveController(
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
            _targetPosition = _moveComponent.GetPosition();
            _touchInputMovementHandler.OnPositionChange += MovePlayerToCoordinates;
        }

        public void Dispose()
        {
            _touchInputMovementHandler.OnPositionChange -= MovePlayerToCoordinates;
        }

        public void Move(float deltaTime)
        {
            _moveComponent.MoveTowards(_targetPosition, deltaTime);
        }

        private void MovePlayerToCoordinates(Vector3 target)
        {
            var newPosition = GetNewPosition(target);
            _targetPosition = ClampPosition(newPosition);
        }

        private Vector3 GetNewPosition(Vector3 targetWorldPosition)
        {
            var currentPosition = _moveComponent.GetPosition();

            var newPositionX = currentPosition.x + targetWorldPosition.x;
            var newPositionY = currentPosition.y + targetWorldPosition.y;

            return new Vector3(newPositionX, newPositionY, 0);
        }

        private Vector3 ClampPosition(Vector3 newPosition)
        {
            var size = _colliderComponent.GetSize();
            return _worldCoordinates.ClampToScreen(newPosition, size.x, size.y);
        }
    }
}