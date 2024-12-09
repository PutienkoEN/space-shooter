using Game.Modules.MainMenu.Scripts;
using Game.Modules.Manager.Scripts;
using Game.UI.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.Modules.Manager
{
    public class MainMenuInstaller : GameModuleInstaller
    {
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button quitGameButton;
        [SerializeField] private Animator animator;

        public override void Install(DiContainer container)
        {
            container
                .Bind<TimeScaleResetter>()
                .AsSingle()
                .NonLazy();
            
            container
                .Bind<MainMenuAnimator>()
                .AsSingle()
                .WithArguments(animator);
            
            container
                .BindInterfacesAndSelfTo<MainMenuController>()
                .AsSingle()
                .WithArguments(startGameButton, quitGameButton)
                .NonLazy();
        }
    }
}