using System;

namespace Game.Modules.BulletModule.Scripts
{
    public interface IDamagable
    {
        public event Action<int> OnDamage;
        public int GetLayer();
        public void InvokeOnDamage(int damage);
    }
}