using Game.Modules.GameSpeed;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules
{
    public class DebugGameSpeedManager : MonoBehaviour
    {
        private IGameSpeedManager _gameSpeedManager;

        [Inject]
        public void Construct(IGameSpeedManager gameSpeedManager)
        {
            _gameSpeedManager = gameSpeedManager;
        }

        [Button]
        public void StartSlow()
        {
            _gameSpeedManager.StartSlowdown();
        }

        [Button]
        public void StopSlow()
        {
            _gameSpeedManager.StopSlowdown();
        }
    }
}