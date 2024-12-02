using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.UI.Scripts
{
    public class MenuManagerInstaller : GameModuleInstaller
    {
        [SerializeField] private Animator animator;
        
        public override void Install(DiContainer container)
        {
            container.BindInterfacesTo<MainMenuManager>().AsSingle().WithArguments(animator);
        }
    }
}