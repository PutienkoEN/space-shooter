using Game.Modules.Common.Interfaces;

namespace SpaceShooter.Game.Player.Ship
{
    public interface IPlayerShipView : IDamageable
    {
        public void Destroy();
    }
}