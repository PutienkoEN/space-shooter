using Game.Modules.Common.Interfaces;

namespace Game.Modules.Components
{
    public class CollisionDamageComponent
    {
        private readonly int _collisionDamage;

        public CollisionDamageComponent(int collisionDamage)
        {
            _collisionDamage = collisionDamage;
        }

        public void DealDamage(IDamageable target)
        {
            target.TakeDamage(_collisionDamage);
        }
    }
}