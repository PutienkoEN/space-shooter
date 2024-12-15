using UnityEngine;

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IPlayerPositionProvider
    {
        public Transform GetTransform();
    }
}