using UnityEngine;

namespace Effects.Explosion
{
    [RequireComponent(typeof(Animator))]
    public class PickupEffect : Effect
    {
        private const string ANIMATION_NAME = "Pickup";
        private int _pickup;
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _pickup = Animator.StringToHash(ANIMATION_NAME);
            _animator.Play(_pickup);
        }

        protected override float GetDuration()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}