using UnityEngine;
using BackgroundModule;
using SpaceShooter;

namespace Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BackgroundScroller>().AsSingle().NonLazy();
            Container.Bind<BackgroundView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<SettingsManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}