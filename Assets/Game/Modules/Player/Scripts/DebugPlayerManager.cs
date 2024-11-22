using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class DebugPlayerManager : MonoBehaviour
    {
        private PlayerManager _playerManager;

        [Inject]
        public void Construct(PlayerManager playerManager)
        {
            _playerManager = playerManager;
        }

        [Button]
        public void CreatePlayer()
        {
            _playerManager.CreatePlayer();
        }
        
        [Button]
        public void Destroy()
        {
            
            _playerManager.DestroyPlayer();
        }
    }
}