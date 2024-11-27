using Game.Modules.ShootingModule.Scripts.ScriptableObjects;
using SpaceShooter.Game.LifeCycle.Common;

namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponController
    {
        private readonly IWeaponComponent _activeIWeaponComponent;
        
        public WeaponController(
            WeaponConfig weaponConfig,
            IWeaponCreator weaponCreator,
            IEntityView playerView)
        {
            _activeIWeaponComponent = weaponCreator.CreateWeapon(weaponConfig, playerView);
        }
        
        public void Tick(float deltaTime)
        {
            _activeIWeaponComponent.Fire(deltaTime);
        }
        
    }
}