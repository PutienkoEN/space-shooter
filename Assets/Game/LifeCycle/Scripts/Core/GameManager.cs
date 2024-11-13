// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: GameManager.cs
// ------------------------------------------------------------------------------

using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    internal sealed class GameManager : IGameManager
    {
        private GameState _gameState = GameState.OFF;
        public GameState State => _gameState;

        private readonly List<IGameListener> _gameListenersList = new();

        [Inject]
        public GameManager()
        {
            Debug.Log("[GameManager] Constructor");
        }

        public void AddListener(IGameListener gameListener)
        {
            _gameListenersList.Add(gameListener);
        }

        public void RemoveListener(IGameListener gameListener)
        {
            _gameListenersList.Remove(gameListener);
        }

        public void StartGame()
        {
            if (_gameState != GameState.OFF)
                return;

            _gameState = GameState.PLAY;
            foreach (var it in _gameListenersList)
            {
                if (it is IGameStartListener startListener)
                {
                    startListener.OnGameStart();
                }
            }
            Debug.Log("[GameManager] StartGame");
        }

        public void PauseGame()
        {
            if (_gameState != GameState.PLAY)
                return;

            _gameState = GameState.PAUSE;
            foreach (var it in _gameListenersList)
            {
                if (it is IGamePauseListener startListener)
                {
                    startListener.OnGamePause();
                }
            }
            Debug.Log("[GameManager] PauseGame");
        }

        public void ResumeGame()
        {
            if (_gameState != GameState.PAUSE)
                return;

            _gameState = GameState.PLAY;
            foreach (var it in _gameListenersList)
            {
                if (it is IGameResumeListener startListener)
                {
                    startListener.OnGameResume();
                }
            }
            Debug.Log("[GameManager] ResumeGame");
        }

        public void FinishGame()
        {
            if (_gameState != GameState.PLAY)
                return;

            _gameState = GameState.FINISH;
            foreach (var it in _gameListenersList)
            {
                if (it is IGameFinishListener startListener)
                {
                    startListener.OnGameFinish();
                }
            }
            Debug.Log("[GameManager] FinishGame");
        }
    }
}