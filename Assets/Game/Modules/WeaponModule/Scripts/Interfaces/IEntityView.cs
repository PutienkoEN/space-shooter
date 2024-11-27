using UnityEngine;

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IEntityView
    {
        public Transform GetTransform();
        public LayerMask GetLayerMask();
    }
}