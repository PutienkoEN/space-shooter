using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IDamagable
    {
        public event Action<int> OnTakeDamage;
        public int GetLayer();
        public void InvokeOnDamage(int damage);
    }
}