using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Scripts
{
    public class MenuManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Button startGameButton;
        [SerializeField] private Button quitGameButton;
        
        public override void Install(DiContainer container)
        {
            container.BindInterfacesTo<MainMenuManager>().AsSingle().WithArguments(animator, startGameButton, quitGameButton);
        }
    }
}