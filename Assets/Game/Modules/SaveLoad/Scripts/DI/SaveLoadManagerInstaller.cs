using SpaceShooter.Game.LifeCycle.Common;
using Zenject;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadManagerInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container
                .BindInterfacesTo<SaveLoadGameFinishListener>()
                .AsSingle()
                .NonLazy();
        }
    }
}