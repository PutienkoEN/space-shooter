using Game.Modules.LevelInterfaces.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class SceneManagerInstaller : MonoInstaller
    {
        [SerializeReference] private ILevelConfig initialLevel;

        public override void InstallBindings()
        {
            Container
                .Bind<GameSceneManager>()
                .AsSingle()
                .WithArguments(initialLevel)
                .NonLazy();

            Container
                .BindInterfacesTo<LevelProvider>()
                .AsSingle()
                .WithArguments(initialLevel);
        }
    }
}