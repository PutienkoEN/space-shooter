using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponInstaller : MonoInstaller
    {
        [SerializeField] private WeaponDataConfig weaponDataConfig;
        [SerializeField] private GameObject parent;
        public override void InstallBindings()
        {
            GameObject player = Container.ResolveId<GameObject>("Player");
            
            Container.BindFactory<WeaponComponent, WeaponComponent.Factory>();
            Container.BindInterfacesAndSelfTo<WeaponCreator>().AsSingle();
            Container.BindInterfacesAndSelfTo<WeaponController>()
                .AsSingle()
                .WithArguments(weaponDataConfig, player);

        }
        
    }
}