using System;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponComponent
    {
        public event Action OnShoot;

        public void Fire(float deltaTime);
    }
}