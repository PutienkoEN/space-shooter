using SpaceShooter.Background;

namespace Zenject
{
    public class BackgroundInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BackgroundController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BackgroundView>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}