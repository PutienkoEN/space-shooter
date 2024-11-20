using SpaceShooter.Game.GameSpeed;
using UnityEngine;
using UnityEngine.Audio;
using Zenject;

namespace Game.Modules.GameSpeed
{
    [RequireComponent(typeof(AudioMixer))]
    public class GameSpeedInstaller : MonoInstaller
    {
        [Tooltip("This is base speed scale of the game. Where 1.0f is 100% speed")] [Range(0, 2f)] [SerializeField]
        private float gameSpeedInitialScale = 1.0f;

        [Tooltip("This is speed scale when game slowed down. Where 0.5f is 50% speed")] [Range(0, 2f)] [SerializeField]
        private float gameSpeedSlowdownScale = 0.5f;

        [Tooltip("This is time in seconds required to slow down game speed to GameSpeedSlowdownScale")] [SerializeField]
        private float timeForFullSlowDown = 0.5f;

        [Tooltip("This is time in seconds required to restore game speed to gameSpeedInitialScale")] [SerializeField]
        private float timeForFullSpeedup = 0.5f;

        [Tooltip("This audio mixer should be used for all sound sources that requires slow down of the sound.")]
        [SerializeField]
        private AudioMixer audioMixer;

        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameSpeedManager>()
                .AsSingle()
                .WithArguments(gameSpeedInitialScale, gameSpeedSlowdownScale, timeForFullSlowDown, timeForFullSpeedup);

            Container
                .BindInterfacesTo<GameAudioSpeedManager>()
                .AsSingle()
                .WithArguments(audioMixer);

            Container
                .BindInterfacesTo<GameTimeScaleManager>()
                .AsSingle();

            Container
                .BindInterfacesTo<UserInputGameSpeedController>()
                .AsSingle()
                .NonLazy();
        }
    }
}