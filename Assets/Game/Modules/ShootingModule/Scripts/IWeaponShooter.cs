namespace Game.Modules.ShootingModule.Scripts
{
    public interface IWeaponShooter
    {
        public void SetActiveWeapon(IWeapon weapon);
        public void Shoot(float deltaTime);
    }
}