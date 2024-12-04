using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Modules.AnimationModule.Scripts
{
    public class ParticlePlayTest : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionEffect1;
        [SerializeField] private ParticleSystem _explosionEffect2;
        
        
        [Button]
        private void Play1()
        {
            DOTween.Sequence()
                .Append(DOTween.To(PlayParticle1, 0, 1, _explosionEffect1.main.duration))
                .OnComplete(Stopped);
            
        }
        
        [Button]
        private void Play2()
        {
            DOTween.Sequence()
                .Append(DOTween.To(PlayParticle2, 0, 1, _explosionEffect2.main.duration))
                .OnComplete(Stopped);
            
        }
        
        private void PlayParticle1(float f)
        {
            if(!_explosionEffect1.isPlaying)
                _explosionEffect1.Play();
        }
        
        private void PlayParticle2(float f)
        {
            if(!_explosionEffect2.isPlaying)
                _explosionEffect2.Play();
        }

        private void Stopped()
        {
            Debug.Log("Particle stopped");
        }
        
        
    }
}