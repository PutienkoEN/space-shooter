using SpaceShooter.Game.Level;
using UnityEngine;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class SceneManagerInstaller : MonoInstaller
    {
        [SerializeField] private GameLevelConfig initialLevel;

        public override void InstallBindings()
        {
            Container
                .Bind<GameContext>()
                .AsSingle();

            Container
                .Bind<GameSceneManager>()
                .AsSingle()
                .WithArguments(initialLevel)
                .NonLazy();
        }
    }
}