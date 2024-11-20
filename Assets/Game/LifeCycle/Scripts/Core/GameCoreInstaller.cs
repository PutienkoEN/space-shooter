using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    [CreateAssetMenu(
        fileName = "GameCoreInstaller",
        menuName = "SpaceShooter/Installers/GameCoreInstaller")]
    internal sealed class GameCoreInstaller : ScriptableObjectInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<GameManager>()
                .AsSingle();

            Container
                .Bind<DOTweenConfiguration>()
                .AsSingle()
                .NonLazy();
        }
    }
}