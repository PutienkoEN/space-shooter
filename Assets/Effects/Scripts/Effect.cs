using UnityEngine;

namespace Effects.Explosion
{
    [RequireComponent(typeof(IEffectRunner))]
    public sealed class Effect : MonoBehaviour, IEffect
    {
        private IEffectRunner EffectRunner => GetComponent<IEffectRunner>();
        public IEffect Instantiate(Vector3 position, Quaternion rotation)
        {
            var instance = Instantiate(this, position, rotation);
            return instance.GetComponent<IEffect>();
        }

        public void Destroy()
        {
            GameObject.Destroy(this.gameObject);
        }

        public float GetDuration()
        {
            return EffectRunner.GetDuration();
        }
    }
}