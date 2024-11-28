using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.Enemy.Scripts
{
    public class DebugLevelManager : MonoBehaviour
    {
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private EnemyEntity enemyEntity;
        [SerializeField] private GameLevelConfig gameLevelConfig;

        private IEnemyManager _enemyManager;
        private LevelManager _levelManager;

        [Inject]
        public void Construct(IEnemyManager enemyManager, LevelManager levelManager)
        {
            _enemyManager = enemyManager;
            _levelManager = levelManager;
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
        public void StartLevel()
        {
            _levelManager.StartLevel(gameLevelConfig.GetData());
        }
    }
}