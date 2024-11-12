// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: SampleInstaller.cs
// ------------------------------------------------------------------------------

using Zenject;

namespace SpaceShooter.Game.Core.Sample
{
    internal sealed class SampleInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameStateControllerSample>().AsSingle().NonLazy();

            
        }
    }
}