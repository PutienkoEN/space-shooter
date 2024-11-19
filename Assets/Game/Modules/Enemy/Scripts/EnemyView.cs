// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    public interface IEnemyView
    {
        event Action<EnemyView> OnDeath;
    }
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public event Action<EnemyView> OnDeath;
        
        [Button]
        private void Death()
        {
            OnDeath?.Invoke(this);
        }
    }
}