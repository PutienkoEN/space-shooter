using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.CameraUtility
{
    public class CameraInstaller : GameModuleInstaller
    {
        [SerializeField] private Camera mainCamera;

        public override void Install(DiContainer container)
        {
            container
                .Bind<Camera>()
                .FromInstance(mainCamera)
                .AsSingle();

            container
                .Bind<WorldCoordinates>()
                .AsSingle();
        }
    }
}