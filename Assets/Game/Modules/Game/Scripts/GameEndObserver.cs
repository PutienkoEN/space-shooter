using System;
using SpaceShooter.Game.Enemy;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Game
{
    public class GameEndObserver : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;
        
        private readonly LevelEventManager _levelEventManager;
        private readonly IEnemyManager _enemyManager;

        private bool _enemiesExist;
        private bool _levelEventsExists;

        public GameEndObserver(
            IGameManager gameManager,
            LevelEventManager levelEventManager,
            IEnemyManager enemyManager)
        {
            _gameManager = gameManager;
            _levelEventManager = levelEventManager;
            _enemyManager = enemyManager;
        }

        public void Initialize()
        {
            _levelEventManager.OnLevelEventChange += CheckGameEndOnLevelEventChange;
            _enemyManager.OnEnemyChange += CheckGameEndOnEnemyChange;
        }

        public void Dispose()
        {
            _levelEventManager.OnLevelEventChange -= CheckGameEndOnLevelEventChange;
            _enemyManager.OnEnemyChange += CheckGameEndOnEnemyChange;
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

        private void CheckGameEnd()
        {
            if (_levelEventsExists)
            {
                return;
            }

            if (_enemiesExist)
            {
                return;
            }
            
            _gameManager.FinishGame();
        }
    }
}