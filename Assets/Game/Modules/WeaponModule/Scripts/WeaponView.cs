using System;
using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponView : MonoBehaviour, IWeaponView
    {
        public AudioSource audioSource;
        public Transform[] firePoints;
        
        private IWeaponDestructible _destructible;

        public Transform[] GetFirePoints()
        {
            return firePoints;
        }

        public void SubscribeToOnDestroy(IWeaponDestructible destructible)
        {
            _destructible = destructible;
            _destructible.OnDestroy += Destroy;
        }

        public void PlayShootSound()
        {
            audioSource.Play();
        }

        private void Destroy()
        {
            _destructible.OnDestroy -= Destroy;
            Destroy(gameObject);
        }
    }
}