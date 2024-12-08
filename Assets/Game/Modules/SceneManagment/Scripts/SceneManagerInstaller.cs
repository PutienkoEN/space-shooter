using SpaceShooter.Game.SceneManagement;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.SceneManagementSceneManagement
{
    public class SceneManagerInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableObject initialLevel;
        [SerializeField] private bool enableAutonomousGameScene;

        public override void InstallBindings()
        {
            Container
                .Bind<GameSceneManager>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<LevelProvider>()
                .AsSingle()
                .WithArguments(initialLevel)
                .NonLazy();

            Container
                .BindInterfacesTo<GameContext>()
                .AsSingle()
                .WithArguments(enableAutonomousGameScene)
                .NonLazy();

            Container
                .Bind<DebugSceneManager>()
                .FromComponentInHierarchy()
                .AsSingle();
        }
    }
}