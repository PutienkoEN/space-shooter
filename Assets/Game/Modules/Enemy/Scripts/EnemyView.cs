// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-19
// <file>: EnemyView.cs
// ------------------------------------------------------------------------------

using UnityEngine;

namespace SpaceShooter.Game.Enemy
{
    public interface IEnemyView
    {
        public Collider GetCollider();
        public void Destroy();
    }
    
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        public Collider GetCollider()
        {
            return GetComponentInChildren<Collider>();
        }

        public void Destroy()
        {
            Destroy(transform.gameObject);
        }
    }
}