using System;

namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponComponent
    {
        public event Action OnShoot;

        public void Fire(float deltaTime);
    }

    public interface IWeaponDestructible
    {
        public event Action OnDestroy;
        public void Destroy();
    }
}