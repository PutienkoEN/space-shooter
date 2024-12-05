using Zenject;

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IGameModuleInstaller
    {
        public void Install(DiContainer container);
    }
}