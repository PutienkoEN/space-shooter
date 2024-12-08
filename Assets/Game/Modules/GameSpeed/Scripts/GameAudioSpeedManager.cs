using System;
using DG.Tweening;
using UnityEngine.Audio;
using Zenject;

namespace Game.Modules.GameSpeed
{
    public class GameAudioSpeedManager : IGameAudioSpeedManager
    {
        private const string Pitch = "Pitch";

        private readonly AudioMixer _audioMixer;

        [Inject]
        public GameAudioSpeedManager(AudioMixer audioMixer)
        {
            _audioMixer = audioMixer;
        }

        public void ChangePitch(float pitchScale)
        {
            GetPitchOrThrow();
            SetPitch(pitchScale);
        }

        public Tween ChangePitch(float pitchScale, float duration)
        {
            var initialPitch = GetPitchOrThrow();

            return DOTween
                .To(() => initialPitch,
                    x => initialPitch = x,
                    pitchScale,
                    duration)
                .SetUpdate(true)
                .OnUpdate(() => SetPitch(initialPitch));
        }

        private float GetPitchOrThrow()
        {
            if (!_audioMixer.GetFloat("Pitch", out var initialPitch))
            {
                throw new ArgumentException($"There is no Pitch parameter in AudioMixer : {_audioMixer}");
            }

            return initialPitch;
        }

        private void SetPitch(float pitchScale)
        {
            _audioMixer.SetFloat(Pitch, pitchScale);
        }
    }
}