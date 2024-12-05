using Sirenix.Utilities;
using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    public class GameSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var installers = GetComponentsInChildren<IGameModuleInstaller>();
            installers.ForEach(installer => installer.Install(Container));
        }
    }
}