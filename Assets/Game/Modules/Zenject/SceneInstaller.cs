using SpaceShooter.Background;
using SpaceShooter;

namespace Zenject
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<BackgroundController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<BackgroundView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.Bind<SettingsManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}