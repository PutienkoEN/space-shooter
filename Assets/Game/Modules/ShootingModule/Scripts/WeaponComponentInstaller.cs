using UnityEngine;
using Zenject;

namespace Game.Modules.ShootingModule.Scripts
{
    public class WeaponComponentInstaller : MonoInstaller
    {
        [SerializeField] private GameObject defaultWeapon;
        [SerializeField] private Transform weaponParent;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<WeaponComponent>().
                AsSingle().
                WithArguments(defaultWeapon,weaponParent).
                NonLazy();
        }
    }
}