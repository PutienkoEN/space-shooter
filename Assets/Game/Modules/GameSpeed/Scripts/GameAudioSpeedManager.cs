using System;
using DG.Tweening;
using UnityEngine.Audio;
using Zenject;

namespace Game.Modules.GameSpeed
{
    public class GameAudioSpeedManager : IGameAudioSpeedManager
    {
        private readonly AudioMixer _audioMixer;

        [Inject]
        public GameAudioSpeedManager(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public Tween ChangePitch(float pitchScale, float duration)
        {
            if (!_audioMixer.GetFloat("Pitch", out var initialPitch))
            {
                throw new ArgumentException($"There is no Pitch parameter in AudioMixer : {_audioMixer}");
            }

            return DOTween
                .To(() => initialPitch,
                    x => initialPitch = x,
                    pitchScale,
                    duration)
                .SetUpdate(true)
                .OnUpdate(() => _audioMixer.SetFloat("Pitch", initialPitch));
        }
    }
}