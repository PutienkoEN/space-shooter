using UnityEngine;

namespace Game.Modules.SoundManagement
{
    public interface ISoundFXManager
    {
        public void PlaySound(AudioClip clip, Transform spawnTransform);
    }
}