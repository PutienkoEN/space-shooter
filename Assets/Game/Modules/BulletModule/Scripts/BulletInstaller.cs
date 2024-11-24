using SpaceShooter.Game.Components;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletInstaller : MonoInstaller
    {
        [Inject] private float _speed;
        public override void InstallBindings()
        {
            Container.Bind<BulletEntity>().AsSingle();
            Container.Bind<BulletView>().FromComponentOnRoot().AsSingle();
            Container.Bind<MoveComponent>().AsSingle()
                .WithArguments(transform, _speed);
        }
    }
}