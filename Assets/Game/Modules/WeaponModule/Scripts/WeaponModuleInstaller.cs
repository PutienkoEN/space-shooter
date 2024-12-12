using Game.Modules.ShootingModule.Scripts;
using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule
{
    public class WeaponModuleInstaller : GameModuleInstaller
    {
        public override void Install(DiContainer container)
        {
            container.BindFactory<WeaponConfig, Transform[], int,
                WeaponComponent, WeaponComponent.Factory>();

            container.Bind<IFactory<WeaponConfig, Transform[], int, WeaponComponent>>()
                .To<WeaponComponent.Factory>().FromResolve();

            container.BindInterfacesAndSelfTo<WeaponCreator>().AsSingle();
        }
    }
}