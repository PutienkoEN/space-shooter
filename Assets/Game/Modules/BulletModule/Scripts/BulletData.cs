namespace Game.Modules.BulletModule
{
    public struct BulletData
    {
        public int Damage { get; private set; }
        public float Speed { get; private set; }

        public BulletData(int damage, float speed)
        {
            Damage = damage;
            Speed = speed;
        }
    }
}