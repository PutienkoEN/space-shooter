using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponentInstaller : MonoInstaller
    {
        [SerializeField] private WeaponConfig weaponConfig;
        [SerializeField] private Transform weaponParent;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponComponent>().
                AsSingle().
                WithArguments(weaponConfig,weaponParent, Container).
                NonLazy();
        }
    }
}