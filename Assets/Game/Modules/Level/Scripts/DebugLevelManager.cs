using Game.Modules.Common.Interfaces;
using Game.Modules.LevelInterfaces.Scripts;
using Sirenix.OdinInspector;
using SpaceShooter.Game.Enemy;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Splines;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class DebugLevelManager : MonoBehaviour
    {
        [BoxGroup("ENEMY")] [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private IEnemyEntity enemyEntity;
        [BoxGroup("ENEMY")] [SerializeField] private SplineContainer splineAnimate;

        private IEnemyManager _enemyManager;
        private LevelManager _levelManager;
        private LevelEventManager _levelEventManager;
        private IGameContext _gameContext;

        [Inject]
        public void Construct(
            IEnemyManager enemyManager,
            LevelManager levelManager,
            LevelEventManager levelEventManager,
            IGameContext gameContext)
        {
            _enemyManager = enemyManager;
            _levelManager = levelManager;
            _levelEventManager = levelEventManager;
            _gameContext = gameContext;
        }

        [BoxGroup("ENEMY")]
        [Button]
        public void CreateEnemy()
        {
            var position = new Vector3(0, 10, 0);
            var rotation = Quaternion.Euler(0, 0, 180);

            var enemyCreateData = new EnemyCreateData(position, rotation, splineAnimate, enemyConfig.GetData());
            enemyEntity = _enemyManager.CreateEnemy(enemyCreateData);
        }

        [BoxGroup("ENEMY")]
        [Button]
        public void DestroyEnemy()
        {
            if (enemyEntity is EnemyEntity enemy)
            {
                _enemyManager.DestroyEnemy(enemy);
            }
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
            var levelConfig = _levelManager.GetLevel();
            _levelEventManager.StartLevel(levelConfig);
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