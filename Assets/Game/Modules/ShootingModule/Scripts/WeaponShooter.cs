namespace Game.Modules.ShootingModule.Scripts
{
    public sealed class WeaponShooter : IWeaponShooter
    {
        private IWeapon _activeWeapon;

        public void SetActiveWeapon(IWeapon weapon)
        {
            _activeWeapon = weapon;
        }

        public void Shoot(float deltaTime)
        {
            _activeWeapon.Fire(deltaTime);
        }
        
    }
}