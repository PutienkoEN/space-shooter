using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.SoundManagement.Scripts
{
    public class SoundManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private AudioClip battleMusic;
        [SerializeField] private AudioClip gameEndMusic;

        public override void Install(DiContainer container)
        {
            container
                .BindInterfacesAndSelfTo<BackgroundSoundGameListener>()
                .AsSingle()
                .WithArguments(audioSource, battleMusic, gameEndMusic)
                .NonLazy();
        }
    }
}