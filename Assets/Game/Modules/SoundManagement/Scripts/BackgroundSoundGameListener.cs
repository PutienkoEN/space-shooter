using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.SoundManagement.Scripts
{
    public class BackgroundSoundGameListener : IGameStartListener, IGameFinishListener
    {
        private readonly AudioSource _audioSource;

        private readonly AudioClip _battleAudioClip;
        private readonly AudioClip _gameEndAudioClip;

        [Inject]
        public BackgroundSoundGameListener(
            AudioSource audioSource,
            AudioClip battleAudioClip,
            AudioClip gameEndAudioClip)
        {
            _audioSource = audioSource;
            _battleAudioClip = battleAudioClip;
            _gameEndAudioClip = gameEndAudioClip;
        }

        public void OnGameStart()
        {
            _audioSource.clip = _battleAudioClip;
            _audioSource.Play();
        }

        public void OnGameFinish()
        {
            _audioSource.clip = _gameEndAudioClip;
            _audioSource.Play();
        }
    }
}