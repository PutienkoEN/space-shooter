using UnityEngine;
using Zenject;

namespace Game.Modules.Manager.Scripts
{
    public class SceneManagerInstaller : MonoInstaller
    {
        [SerializeField] private ScriptableObject initialLevel;

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
        }
    }
}