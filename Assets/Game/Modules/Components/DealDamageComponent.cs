using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class DealDamageComponent
    {
       
        public bool TryDealDamage(Collider otherObject, int layer, int damage)
        {
            var damagable = otherObject.gameObject.GetComponentInParent<IDamagable>();
            if(damagable != null)
            {
                damagable.InvokeOnDamage(damage);
                
                return true;
            }
            return false;
        }
    }
}