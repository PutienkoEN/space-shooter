using Game.Modules.BulletModule.Scripts;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule
{
    public sealed class BulletInstaller : MonoInstaller
    {
        [Inject] private BulletData _bulletData;

        public override void InstallBindings()
        {
            Container
                .Bind<BulletEntity>()
                .AsSingle()
                .WithArguments(_bulletData.Damage);

            Container
                .Bind<BulletView>()
                .FromComponentOnRoot()
                .AsSingle();

            var colliderComponent = transform.GetComponent<Collider>();
            Container
                .Bind<ColliderComponent>()
                .AsSingle()
                .WithArguments(colliderComponent)
                .NonLazy();

            Container
                .Bind<MoveComponent>()
                .AsSingle()
                .WithArguments(transform, _bulletData.Speed);

            Container
                .Bind<BoundsCheckComponent>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ColliderRectProvider>()
                .AsSingle();
        }
    }
}