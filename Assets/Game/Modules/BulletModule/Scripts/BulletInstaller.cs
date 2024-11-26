using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BulletInstaller : MonoInstaller
    {
        private float _speed;
        
        [Inject]
        private void Construct(float speed)
        {
            _speed = speed;
        }
        
        public override void InstallBindings()
        {
            Container.Bind<BulletEntity>().AsSingle();
            Container.Bind<BulletView>().FromComponentOnRoot().AsSingle();

            var collider = transform.GetComponent<Collider>();
            Container.Bind<ColliderComponent>().AsSingle().WithArguments(collider).NonLazy();
            
            Container.Bind<MoveComponent>().AsSingle()
                .WithArguments(transform, _speed);
        }
    }
}