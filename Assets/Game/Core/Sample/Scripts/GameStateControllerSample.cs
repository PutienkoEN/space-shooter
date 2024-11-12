// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: GameStateControllerSample.cs
// ------------------------------------------------------------------------------

using SpaceShooter.Game.Core.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Core.Sample
{
    //TODO ITickable use only for sample GameState.
    internal sealed class GameStateControllerSample : ITickable
    {
        private readonly IGameManagerState _gameManager;

        [Inject]
        public GameStateControllerSample(IGameManagerState gameManager)
        {
            _gameManager = gameManager;
            Debug.Log("[GameStateControllerSample] Constructor");
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.S)) _gameManager.StartGame();
            if (Input.GetKeyDown(KeyCode.P)) _gameManager.PauseGame();
            if (Input.GetKeyDown(KeyCode.R)) _gameManager.ResumeGame();
            if (Input.GetKeyDown(KeyCode.F)) _gameManager.FinishGame();
        }
    }
}