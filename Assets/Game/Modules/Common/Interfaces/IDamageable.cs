using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IDamageable
    {
        public event Action<int> OnTakeDamage;
        public void TakeDamage(int damage);
    }
}