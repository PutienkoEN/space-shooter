using UnityEngine;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponView : MonoBehaviour, IWeaponView
    {
        public AudioSource audioSource;
        public Transform[] firePoints;

        public Transform[] GetFirePoints()
        {
            return firePoints;
        }

        public void PlayShootSound()
        {
            audioSource.Play();
        }
    }

    public interface IWeaponView
    {
        public void PlayShootSound();
        public Transform[] GetFirePoints();
    }
}