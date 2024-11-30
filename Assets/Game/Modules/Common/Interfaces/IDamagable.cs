using System;

namespace Game.Modules.Common.Interfaces
{
    public interface IDamagable
    {
        public event Action<int> OnDamage;
        public int GetLayer();
        public void InvokeOnDamage(int damage);
    }
}