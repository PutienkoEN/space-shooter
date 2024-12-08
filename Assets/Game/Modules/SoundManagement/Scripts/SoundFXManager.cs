using UnityEngine;

namespace Game.Modules.SoundManagement.Scripts
{
    public class SoundFXManager : MonoBehaviour, ISoundFXManager
    {
        public static ISoundFXManager Instance { get; private set; }

        [SerializeField] private AudioSource audioSourcePrefab;
        [SerializeField] private Transform container;

        private void Awake()
        {
            Instance ??= this;
        }

        public void PlaySound(AudioClip clip, Transform spawnTransform)
        {
            var audioSource = Instantiate(
                audioSourcePrefab,
                spawnTransform.position,
                spawnTransform.rotation,
                container);

            audioSource.clip = clip;

            audioSource.Play();

            Destroy(audioSource.gameObject, clip.length);
        }
    }
}