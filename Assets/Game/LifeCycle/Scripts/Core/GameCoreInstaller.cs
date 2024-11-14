// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: GameCoreInstaller.cs
// ------------------------------------------------------------------------------

using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.LifeCycle.Core
{
    [CreateAssetMenu(
        fileName = "GameCoreInstaller",
        menuName = "SpaceShooter/Installers/GameCoreInstaller")]
    internal sealed class GameCoreInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private Camera camera;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameManager>().AsSingle();
        }
    }
}