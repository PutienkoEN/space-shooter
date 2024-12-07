using System;
using SpaceShooter.Game.Enemy;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player;
using UnityEngine;
using Zenject;

namespace Game.Modules.Game
{
    public class GameEndObserver : IInitializable, IDisposable
    {
     
        private readonly IGameManager _gameManager;

        private readonly LevelEventManager _levelEventManager;
        private readonly IEnemyManager _enemyManager;
        private readonly PlayerManager _playerManager;

        private bool _playerIsDead;
        private bool _enemiesExist;
        private bool _levelEventsExists;

        [Inject]
        public GameEndObserver(
            IGameManager gameManager,
            LevelEventManager levelEventManager,
            IEnemyManager enemyManager,
            PlayerManager playerManager)
        {
            _gameManager = gameManager;
            _levelEventManager = levelEventManager;
            _enemyManager = enemyManager;
            _playerManager = playerManager;
        }

        public void Initialize()
        {
            _levelEventManager.OnLevelEventChange += CheckGameEndOnLevelEventChange;
            _enemyManager.OnEnemyChange += CheckGameEndOnEnemyChange;
            _playerManager.OnPlayerDeath += CheckGameEndPlayerDead;
        }

        public void Dispose()
        {
            _levelEventManager.OnLevelEventChange -= CheckGameEndOnLevelEventChange;
            _enemyManager.OnEnemyChange += CheckGameEndOnEnemyChange;
            _playerManager.OnPlayerDeath -= CheckGameEndPlayerDead;
        }

        private void CheckGameEndOnEnemyChange(bool enemiesExist)
        {
            _enemiesExist = enemiesExist;
            CheckGameEnd();
        }

        private void CheckGameEndOnLevelEventChange(bool levelEventsExist)
        {
            _levelEventsExists = levelEventsExist;
            CheckGameEnd();
        }

        private void CheckGameEndPlayerDead()
        {
            _playerIsDead = true;
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            var shouldStopGame = ShouldStopGame();
            if (shouldStopGame)
            {
                _gameManager.FinishGame();
            }
        }

        private bool ShouldStopGame()
        {
            if (_playerIsDead)
            {
                return true;
            }

            if (_levelEventsExists)
            {
                return false;
            }

            if (_enemiesExist)
            {
                return false;
            }

            return true;
        }
    }
}