using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponentInstaller : MonoInstaller
    {
        [SerializeField] private WeaponConfig weaponConfig;
        public override void InstallBindings()
        {
            // Container.BindInterfacesAndSelfTo<Weapon>().AsSingle();
            // Container.Bind<WeaponSpawner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<WeaponController>()
                .AsSingle()
                .WithArguments(weaponConfig)
                .NonLazy();

            // Container.Bind<WeaponChanger>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}