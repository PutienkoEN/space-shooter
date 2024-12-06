using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.MainMenu.Scripts
{
    public class EndGamePopupInstaller : GameModuleInstaller
    {
        [SerializeField] private Button restartButton;
        [SerializeField] private Button toMainMenuButton;

        public override void Install(DiContainer container)
        {
            container
                .BindInterfacesAndSelfTo<EndGamePopupController>()
                .AsSingle()
                .WithArguments(restartButton, toMainMenuButton)
                .NonLazy();
        }
    }
}