using Game.Modules.LevelInterfaces.Scripts;
using Sirenix.OdinInspector;
using SpaceShooter.Game.Enemy;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class DebugLevelManager : MonoBehaviour
    {
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private EnemyEntity enemyEntity;

        private IEnemyManager _enemyManager;
        private ILevelProvider _levelProvider;
        private LevelEventManager _levelEventManager;

        [Inject]
        public void Construct(
            IEnemyManager enemyManager,
            ILevelProvider levelProvider,
            LevelEventManager levelEventManager)
        {
            _enemyManager = enemyManager;
            _levelProvider = levelProvider;
            _levelEventManager = levelEventManager;
        }

        [Button]
        public void CreateEnemy()
        {
            var position = new Vector3(0, 10, 0);
            var rotation = Quaternion.Euler(0, 0, 180);

            enemyEntity = _enemyManager.CreateEnemy(position, rotation, enemyConfig.GetData());
        }

        [Button]
        public void DestroyEnemy()
        {
            _enemyManager.DestroyEnemy(enemyEntity);
        }

        [Button]
        public void StartCurrentLevel()
        {
            var levelConfig = _levelProvider.GetLevelConfig();
            var levelData = levelConfig.GetData();

            _levelEventManager.StartLevel(levelData);
        }

        [Button]
        public void StartProvidedLevel(LevelConfig levelConfig)
        {
            var levelData = levelConfig.GetData();
            _levelEventManager.StartLevel(levelData);
        }
    }
}