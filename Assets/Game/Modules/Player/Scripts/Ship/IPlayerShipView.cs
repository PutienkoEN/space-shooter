using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public interface IPlayerShipView : IEntityView, ICollidable, IDamageDealer, IDamageable
    {
        public Transform GetTransform();
    }
}