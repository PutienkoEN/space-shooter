using Sirenix.OdinInspector;
using SpaceShooter.Game.Player.Ship;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class DebugPlayerManager : MonoBehaviour
    {
        private PlayerManager _playerManager;
        private PlayerShipEntity _playerShipEntity;


        [Inject]
        public void Construct(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        [Button]
        private void TakeDamage(float damage)
        {
            _playerShipEntity.TakeDamage(damage);
        }

        [Button]
        public void CreatePlayer()
        {
            _playerShipEntity = _playerManager.CreatePlayer();
        }

        [Button]
        public void Destroy()
        {
            _playerManager.DestroyPlayer();
        }
    }
}