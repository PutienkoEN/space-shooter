using UnityEngine;

namespace Effects.Explosion
{
    public interface IEffect
    {
        public IEffect Instantiate(Vector3 position, Quaternion rotation);
        public void Destroy();
        public float GetDuration();
    }
}