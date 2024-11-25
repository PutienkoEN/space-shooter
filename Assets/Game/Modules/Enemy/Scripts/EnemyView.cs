// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace Game.Modules.Enemy.Scripts
{
    public interface IEnemyView
    {
        public void Destroy();
    }

    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}