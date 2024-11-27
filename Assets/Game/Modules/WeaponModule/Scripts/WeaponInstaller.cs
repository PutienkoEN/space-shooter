using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponConfig weaponConfig;

        public override void InstallBindings()
        {
            Container.BindFactory<WeaponComponent, WeaponComponent.Factory>();
            Container.BindInterfacesAndSelfTo<WeaponCreator>().AsSingle();
            Container.Bind<WeaponController>()
                .AsSingle()
                .WithArguments(weaponConfig, gameObject.transform);

        }
        
    }
}