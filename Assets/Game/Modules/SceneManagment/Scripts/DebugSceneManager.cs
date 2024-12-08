using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.SceneManagement
{
    public class DebugSceneManager : MonoBehaviour
    {
        private GameSceneManager _gameSceneManager;

        [Inject]
        public void Construct(GameSceneManager gameSceneManager)
        {
            _gameSceneManager = gameSceneManager;
        }

        [Button]
        public void ReloadGameScene()
        {
            _gameSceneManager.LoadGameScene();
        }
    }
}