using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletInstaller : MonoInstaller
    {
        [SerializeField] private BulletFacade bulletFacade;
        public override void InstallBindings()
        {
            Container.Bind<MoveComponent>().AsSingle();
        }
    }
}