using System;
using Game.Modules.Enemy.Scripts;
using UnityEngine;

namespace Game.Modules.EnemyGroup.Scripts
{
    [Serializable]
    public class EnemyGroup
    {
        [SerializeField] private int numberOfEnemies;
        [SerializeField] private EnemyConfig enemyConfig;
    }
}