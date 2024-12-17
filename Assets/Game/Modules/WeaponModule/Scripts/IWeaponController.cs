using Game.Modules.ShootingModule.Scripts.ScriptableObjects;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponController
    {
        public void Tick(float deltaTime);
        public void ChangeWeapon(WeaponData weaponData);
    }
}