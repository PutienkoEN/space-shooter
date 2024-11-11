using Zenject;

namespace SpaceShooter.Zenject
{
    public class SettingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SettingsManager>().FromComponentInHierarchy().AsSingle().NonLazy();
        }

    }
}