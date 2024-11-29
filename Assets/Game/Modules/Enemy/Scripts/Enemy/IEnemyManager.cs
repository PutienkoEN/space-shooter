using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    public interface IEnemyManager
    {
        public EnemyEntity CreateEnemy(Vector3 position, Quaternion rotation, EnemyData enemyData);
        public void DestroyEnemy(EnemyEntity enemyEntity);
    }
}