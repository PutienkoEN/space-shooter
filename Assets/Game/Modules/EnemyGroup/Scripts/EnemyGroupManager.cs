// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: EnemyGroupManager.cs
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Game.Modules.Enemy.Scripts;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Modules.EnemyGroup.Scripts
{
    public interface IEnemyGroupManager
    {
        event Action OnDeathAllEnemy;
        public void SpawnEnemies(IEnumerable<EnemyData> enemiesData);
    }
    
    //TODO This class will work on all enemy groups on the stage.
    public sealed class EnemyGroupManager : IEnemyGroupManager, IDisposable
    {
        public event Action OnDeathAllEnemy;
        private readonly HashSet<EnemyView> _enemiesActive = new();
        private readonly IEnemyFactory _enemyFactory;

        public EnemyGroupManager(IEnemyFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public void SpawnEnemies(IEnumerable<EnemyData> enemiesData)
        {
            foreach (var data in enemiesData)
            {
                var enemy = _enemyFactory.CreateEnemy(data);
                _enemiesActive.Add(enemy);
                enemy.OnDeath += OnEnemyDeath;
            }
        }

        private void OnEnemyDeath(EnemyView enemy)
        {
            Debug.Log($"Enemy {enemy.name} died. Remaining enemies: {_enemiesActive.Count}");
            enemy.OnDeath -= OnEnemyDeath;
            _enemiesActive.Remove(enemy);
            Object.Destroy(enemy.gameObject);
            CheckDeathAllEnemy();
        }

        private void CheckDeathAllEnemy()
        {
            if (_enemiesActive.Count > 0)
                return;
            
            OnDeathAllEnemy?.Invoke();
        }

        public void Dispose()
        {
            foreach (var enemy in _enemiesActive)
            {
                enemy.OnDeath -= OnEnemyDeath;
                Object.Destroy(enemy.gameObject);
            }
            _enemiesActive.Clear();
        }
    }
}