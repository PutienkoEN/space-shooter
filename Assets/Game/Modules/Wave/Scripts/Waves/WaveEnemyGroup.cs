// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: WaveEnemyGroup.cs
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Game.Modules.Enemy.Scripts;
using Game.Modules.EnemyGroup.Scripts;
using Game.Modules.Wave.Config;
using UnityEngine;

namespace Game.Modules.Wave.Waves
{
    public sealed class WaveEnemyGroup : IWave
    {
        public event Action OnWaveFinished;
        private readonly IEnemyGroupManager _enemyGroupManager;
        private IReadOnlyList<EnemyGroupData> _listEnemyGroupData;
        
        public WaveEnemyGroup(IEnemyGroupManager enemyGroupManager)
        {
            _enemyGroupManager = enemyGroupManager;
        }

        public IWave Init(IWaveData data)
        {
            if (data is not WaveEnemyGroupData enemyGroupData)
            {
                throw new InvalidOperationException($"[WaveDelay] Unknown wave data type: {data.GetType()}");
            }
            
            _listEnemyGroupData = enemyGroupData.listEnemyGroupData;
            
            return this;
        }

        public void StartWave()
        {
            Debug.Log("[WaveEnemyGroup] StartWave");
            _enemyGroupManager.OnDeathAllEnemy += OnDeathAllEnemy;
            foreach (var enemyGroupData in _listEnemyGroupData)
            {
                _enemyGroupManager.SpawnEnemies(enemyGroupData.listEnemyData);
            }
        }

        private void OnDeathAllEnemy()
        {
            _enemyGroupManager.OnDeathAllEnemy -= OnDeathAllEnemy;
            OnWaveFinished?.Invoke();
        }

        public void Dispose()
        {
            
        }
    }
}