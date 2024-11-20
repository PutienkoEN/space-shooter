// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: EnemyGroupManagerDebug.cs
// ------------------------------------------------------------------------------

using Game.Modules.Enemy.Scripts;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Modules.EnemyGroup.Scripts
{
    public class EnemyGroupManagerDebug : MonoBehaviour
    {
        private EnemyGroupConfig _enemyGroupConfig; 
        private EnemyGroupManager _enemyGroupManager;
        
        [Inject]
        public void Constructor(EnemyGroupConfig enemyGroupConfig, EnemyGroupManager enemyGroupManager)
        {
            _enemyGroupConfig = enemyGroupConfig;
            _enemyGroupManager = enemyGroupManager;
            
            Debug.Log("[EnemyGroupManagerDebug] Constructor");
        }

        [Button]
        private void SpawnGroup()
        {
            _enemyGroupManager.SpawnEnemies(_enemyGroupConfig.GetEnemyGroupData().listEnemyData);
        }
    }
}