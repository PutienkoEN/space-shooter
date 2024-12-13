using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class PlayerTargetStrategy : ITargetStrategy
    {
        private readonly IPlayerPositionProvider _playerManager;

        private Transform _transform;

        [Inject]
        public PlayerTargetStrategy(IPlayerPositionProvider playerManager)
        {
            _playerManager = playerManager;
        }

        public Vector3 GetTarget()
        {
            if (_transform == null)
            {
                SetPlayerTransform();
            }

            if (_transform != null)
            {
                return _transform.position;
            }

            Debug.LogWarning("Player ship entity is null");
            return Vector3.zero;
        }

        private void SetPlayerTransform()
        {
            var playerShipEntity = _playerManager.GetTransform();
            if (playerShipEntity == null)
            {
                return;
            }

            _transform = playerShipEntity;
        }
    }
}