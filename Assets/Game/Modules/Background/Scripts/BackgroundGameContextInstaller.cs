using Game.Modules.Background.Scripts;
using SpaceShooter.Background;
using SpaceShooter.Background.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace Zenject
{
    public sealed class BackgroundGameContextInstaller : MonoInstaller
    {
        [FormerlySerializedAs("backgroundLayersConfig")] [SerializeField] private BackgroundDataConfig backgroundDataConfig;
        [SerializeField] private Transform parent;

        public override void InstallBindings()
        {
            Container.Bind<BackgroundsInstantiator>().AsSingle().WithArguments(backgroundDataConfig, parent).NonLazy();
            Container.BindInterfacesAndSelfTo<BackgroundController>().AsSingle().NonLazy();
        }
    }
}