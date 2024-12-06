using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IDamageDealer
    {
        public event Action<IDamageable> OnDealDamage;
    }
}