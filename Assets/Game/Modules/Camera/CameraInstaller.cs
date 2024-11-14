using UnityEngine;
using Zenject;

namespace SpaceShooter.Input
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
                .Bind<CameraUtility>()
                .AsSingle();
        }
    }
}