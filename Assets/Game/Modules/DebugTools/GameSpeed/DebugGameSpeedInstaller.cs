using Zenject;

namespace Game.Modules
{
    public class DebugGameSpeedInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<DebugGameSpeedManager>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();
        }
    }
}