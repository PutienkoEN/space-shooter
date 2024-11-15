using Game.Modules.Background.Scripts;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject
{
    public sealed class BackgroundGameContextInstaller : MonoInstaller
    {
        [SerializeField] private BackgroundLayersConfig backgroundLayersConfig;
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundsPresenterInstantiator>().AsSingle().WithArguments(backgroundLayersConfig).NonLazy();
            Container.Bind<BackgroundsInstantiator>().AsSingle().WithArguments(backgroundLayersConfig, parent).NonLazy();
            Container.BindInterfacesAndSelfTo<BackgroundController>().AsSingle().NonLazy();
        }
    }
}