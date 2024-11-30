using Sirenix.OdinInspector;
using SpaceShooter.Game.Enemy;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace SpaceShooter.Game.Level
{
    public class DebugLevelManager : MonoBehaviour
    {
        [SerializeField] private EnemyConfig enemyConfig;
        [SerializeField] private EnemyEntity enemyEntity;
        [FormerlySerializedAs("gameLevelConfig")] [SerializeField] private LevelConfig levelConfig;

        private IEnemyManager _enemyManager;
        private LevelEventManager _levelEventManager;

        [Inject]
        public void Construct(IEnemyManager enemyManager, LevelEventManager levelEventManager)
        {
            _enemyManager = enemyManager;
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
        public void StartLevel()
        {
            _levelEventManager.StartLevel(levelConfig.GetData());
        }
    }
}