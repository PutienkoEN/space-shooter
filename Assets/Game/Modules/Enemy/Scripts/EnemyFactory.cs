// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: EnemyFactory.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    public interface IEnemyFactory
    {
        EnemyView CreateEnemy(EnemyData data);
    }
    
    public sealed class EnemyFactory : IEnemyFactory
    {
        private readonly Transform _worldContainer;

        public EnemyFactory(Transform worldContainer)
        {
            _worldContainer = worldContainer;
        }

        public EnemyView CreateEnemy(EnemyData data)
        {
            return Object.Instantiate(data.enemyView, _worldContainer);
        }
    }
}