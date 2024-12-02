﻿using Game.Modules.LevelInterfaces.Scripts;
using Sirenix.OdinInspector;
using SpaceShooter.Game.Enemy;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class DebugLevelManager : MonoBehaviour
    {
        [BoxGroup("ENEMY")] [SerializeField] private EnemyConfig enemyConfig;
        [BoxGroup("ENEMY")] [SerializeField] private EnemyEntity enemyEntity;

        private IEnemyManager _enemyManager;
        private ILevelProvider _levelProvider;
        private LevelEventManager _levelEventManager;
        private IGameContext _gameContext;

        [Inject]
        public void Construct(
            IEnemyManager enemyManager,
            ILevelProvider levelProvider,
            LevelEventManager levelEventManager,
            IGameContext gameContext)
        {
            _enemyManager = enemyManager;
            _levelProvider = levelProvider;
            _levelEventManager = levelEventManager;
            _gameContext = gameContext;
        }

        [BoxGroup("ENEMY")]
        [Button]
        public void CreateEnemy()
        {
            var position = new Vector3(0, 10, 0);
            var rotation = Quaternion.Euler(0, 0, 180);

            enemyEntity = _enemyManager.CreateEnemy(position, rotation, enemyConfig.GetData());
        }

        [BoxGroup("ENEMY")]
        [Button]
        public void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(enemyEntity);
        }

        [BoxGroup("GAME")]
        [Button]
        public void StartGame()
        {
            _gameContext.GameStart = true;
        }

        [BoxGroup("GAME")]
        [Button]
        public void StartCurrentLevel()
        {
            var levelConfig = _levelProvider.GetLevelConfig();
            var levelData = levelConfig.GetData();

            _levelEventManager.StartLevel(levelData);
        }

        [BoxGroup("GAME")]
        [Button]
        public void StartProvidedLevel(LevelConfig levelConfig)
        {
            var levelData = levelConfig.GetData();
            _levelEventManager.StartLevel(levelData);
        }
    }
}