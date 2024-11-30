using System;
using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class DealDamageEvent : ICollisionEvent
    {
        public ColliderObject ColliderObj;
        public IDamagable CollidedWith;
        
        private const string PLAYER_LAYER = "Player";
        private const string ENEMY_LAYER = "Enemy";
        
        public DealDamageEvent(ColliderObject colliderObj, IDamagable collidedWith)
        {
            ColliderObj = colliderObj;
            CollidedWith = collidedWith;
        }

        public int GetEventKey()
        {
            return HashCode.Combine(ColliderObj.GetHashCode(), CollidedWith.GetHashCode());
        }

        public void Apply()
        {
            if (CollidedWith != null)
            {
                if (PlayerHitsEnemy(ColliderObj.Layer, CollidedWith.GetLayer())
                    || EnemyHitsPlayer(ColliderObj.Layer, CollidedWith.GetLayer()))
                {
                    CollidedWith.InvokeOnDamage(ColliderObj.Damage);
                    Debug.Log("deal damage : " + ColliderObj.Damage);
                }
            }
        }
        
        private bool PlayerHitsEnemy(int colliderLayer, int otherLayer)
        {
            if (colliderLayer == LayerMask.NameToLayer(PLAYER_LAYER)
                && otherLayer == LayerMask.NameToLayer(ENEMY_LAYER))
            {
                return true;
            }
            return false;
        }
        
        private bool EnemyHitsPlayer(int colliderLayer, int otherLayer)
        {
            if (colliderLayer == LayerMask.NameToLayer(ENEMY_LAYER)
                && otherLayer == LayerMask.NameToLayer(PLAYER_LAYER))
            {
                return true;
            }
            return false;
        }
    }

    public interface ICollisionEvent
    {
        public int GetEventKey();
        public void Apply();
    }
}