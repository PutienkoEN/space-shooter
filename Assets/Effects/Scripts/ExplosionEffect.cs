using System;
using System.Threading;
using UnityEngine;

namespace Effects.Explosion
{
    [RequireComponent(typeof(Animator))]
    public class ExplosionEffect : Effect
    {
        private const string ANIMATION_NAME = "Explosion";
        private int _explosion;
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            Animator.StringToHash(ANIMATION_NAME);
            _animator.Play(_explosion);
        }

        protected override float GetDuration()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).length;
        }
    }
}