using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class CollisionConditions
    {
        public bool IsTrue(int colliderLayer, int otherLayer)
        {
            return PlayerHitsEnemy(colliderLayer, otherLayer) 
                || EnemyHitsPlayer(colliderLayer, otherLayer);
        }

        private bool PlayerHitsEnemy(int colliderLayer, int otherLayer)
        {
            if (colliderLayer == LayerMask.NameToLayer("Player")
                && otherLayer == LayerMask.NameToLayer("Enemy"))
            {
                return true;
            }
            return false;
        }
        
        private bool EnemyHitsPlayer(int colliderLayer, int otherLayer)
        {
            if (colliderLayer == LayerMask.NameToLayer("Enemy")
                && otherLayer == LayerMask.NameToLayer("Player"))
            {
                return true;
            }
            return false;
        }
    }
}