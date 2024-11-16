using Game.Modules.Background.Scripts;
using Game.Modules.Background.Scripts.Data;
using SpaceShooter.Background;
using UnityEngine;

namespace Zenject
{
    public sealed class BackgroundGameContextInstaller : MonoInstaller
    {
        [SerializeField] private BackgroundLayersConfig backgroundDataConfig;
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundsInstantiator>().AsSingle().WithArguments(backgroundDataConfig, parent).NonLazy();
            Container.BindInterfacesAndSelfTo<BackgroundController>().AsSingle().NonLazy();
        }
    }
}