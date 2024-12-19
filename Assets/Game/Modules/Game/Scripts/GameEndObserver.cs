using System;
using SpaceShooter.Game.Enemy;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.LifeCycle.Common;
using SpaceShooter.Game.Player;
using Zenject;

namespace Game.Modules.Game
{
    public class GameEndObserver : IInitializable, IDisposable
    {
        private readonly IGameManager _gameManager;

        private readonly LevelEventManager _levelEventManager;
        private readonly IEnemyManager _enemyManager;
        private readonly PlayerManager _playerManager;

        private LevelProgressContext _levelProgressContext;

        [Inject]
        public GameEndObserver(
            IGameManager gameManager,
            LevelEventManager levelEventManager,
            IEnemyManager enemyManager,
            PlayerManager playerManager,
            LevelProgressContext levelProgressContext)
        {
            _gameManager = gameManager;
            _levelEventManager = levelEventManager;
            _enemyManager = enemyManager;
            _playerManager = playerManager;
            _levelProgressContext = levelProgressContext;
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
            _levelProgressContext.EnemiesExist = enemiesExist;
            CheckGameEnd();
        }

        private void CheckGameEndOnLevelEventChange(bool levelEventsExist)
        {
            _levelProgressContext.LevelEventsExists = levelEventsExist;
            CheckGameEnd();
        }

        private void CheckGameEndPlayerDead()
        {
            _levelProgressContext.PlayerIsDead = true;
            CheckGameEnd();
        }

        private void CheckGameEnd()
        {
            if (_levelProgressContext.IsLevelFinished())
            {
                _gameManager.FinishGame();
            }
        }
    }
}