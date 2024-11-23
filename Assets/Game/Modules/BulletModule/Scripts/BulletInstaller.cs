using SpaceShooter.Game.Components;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<NewBullet>().AsSingle();
            Container.Bind<BulletView>().FromComponentOnRoot().AsSingle();
            Container.Bind<MoveComponent>().AsSingle();
        }
    }
}