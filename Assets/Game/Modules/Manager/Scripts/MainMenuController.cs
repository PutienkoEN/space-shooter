using System;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class MainMenuController : IInitializable, IDisposable
    {
        private readonly GameSceneManager _gameSceneManager;
        private readonly Button _startGameButton;

        [Inject]
        public MainMenuController(GameSceneManager gameSceneManager, Button startGameButton)
        {
            _gameSceneManager = gameSceneManager;
            _startGameButton = startGameButton;
        }

        public void Initialize()
        {
            _startGameButton.onClick.AddListener(() => _gameSceneManager.LoadGameScene());
        }

        public void Dispose()
        {
            _startGameButton.onClick.RemoveListener(() => _gameSceneManager.LoadGameScene());
        }
    }
}