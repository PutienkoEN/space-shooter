using Game.Modules.Manager.Scripts;
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
                .BindInterfacesAndSelfTo<MainMenuController>()
                .AsSingle()
                .WithArguments(startGameButton, quitGameButton, animator)
                .NonLazy();
        }
    }
}