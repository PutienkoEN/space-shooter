using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.CameraUtility
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera;

        public override void InstallBindings()
        {
            Container
                .Bind<Camera>()
                .FromInstance(mainCamera)
                .AsSingle();

            Container
                .Bind<WorldCoordinates>()
                .AsSingle();
        }
    }
}