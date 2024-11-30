using System;

namespace Game.Modules.BulletModule.Scripts
{
    public struct ColliderObject : IEquatable<ColliderObject>
    {
        public int Layer;
        public int Damage;

        public ColliderObject(int layer, int damage)
        {
            Layer = layer;
            Damage = damage;
        }

        public bool Equals(ColliderObject other)
        {
            return Layer == other.Layer && Damage == other.Damage;
        }
    }
}