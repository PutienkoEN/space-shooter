using Game.Modules.MainMenu.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.UImodule.Scripts
{
    public sealed class UIControllerInstaller : GameModuleInstaller
    {
        [SerializeField] private EndGamePopupView endGamePopupView;
        
        public override void Install(DiContainer container)
        {
            
            container.Bind<EndGamePopupView>().FromInstance(endGamePopupView);
            
            container
                .BindInterfacesAndSelfTo<EndGamePopupController>()
                .AsSingle()
                .NonLazy();
        }
        
        
    }
}