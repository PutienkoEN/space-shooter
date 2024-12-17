using Game.Modules.MainMenu.Scripts;
using Game.Modules.Manager.Scripts;
using Game.UI.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Manager
{
    public class MainMenuInstaller : GameModuleInstaller
    {
        [SerializeField] private MainMenuView mainMenuView;
        [SerializeField] private Animator animator;

        public override void Install(DiContainer container)
        {
            container
                .Bind<MainMenuAnimator>()
                .AsSingle()
                .WithArguments(animator);

            container
                .Bind<MainMenuView>()
                .FromInstance(mainMenuView)
                .AsSingle();
            
            container
                .BindInterfacesAndSelfTo<MainMenuController>()
                .AsSingle()
                .NonLazy();
        }
    }
}