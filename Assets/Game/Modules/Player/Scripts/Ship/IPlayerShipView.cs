using Game.Modules.Common.Interfaces;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public interface IPlayerShipView : IEntityView, IDamageable, ICollidable, IDamageDealer
    {
        public Transform GetTransform();
    }
}