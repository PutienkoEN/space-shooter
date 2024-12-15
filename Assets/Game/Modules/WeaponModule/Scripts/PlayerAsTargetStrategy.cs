using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class PlayerAsTargetStrategy : ITargetStrategy
    {
        private readonly IPlayerPositionProvider _playerManager;

        private Transform _target;

        [Inject]
        public PlayerAsTargetStrategy(IPlayerPositionProvider playerManager)
        {
            _playerManager = playerManager;
        }

        public Vector3 GetShootDirection(Transform shootPoint)
        {
            if (_target == null)
            {
                SetPlayerTransform();
            }

            if (_target != null)
            {
                return GetDirection(shootPoint);
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

            _target = playerShipEntity;
        }

        private Vector3 GetDirection(Transform shootPoint)
        {
            var direction = _target.position - shootPoint.position;
            return direction.normalized;
        }
    }
}