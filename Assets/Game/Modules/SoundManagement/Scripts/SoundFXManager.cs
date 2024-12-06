using UnityEngine;

namespace Game.Modules.SoundManagement.Scripts
{
    public class SoundFXManager : MonoBehaviour, ISoundFXManager
    {
        public static ISoundFXManager Instance { get; private set; }

        [SerializeField] private AudioSource audioSourcePrefab;

        private void Awake()
        {
            Instance ??= this;
        }

        public void PlaySound(AudioClip clip, Transform spawnTransform)
        {
            var audioSource = Instantiate(audioSourcePrefab, spawnTransform.position, spawnTransform.rotation);
            audioSource.clip = clip;

            audioSource.Play();
        }
    }
}