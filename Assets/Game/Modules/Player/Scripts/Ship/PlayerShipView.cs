using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipView : MonoBehaviour, IEntityView
    {
        public void DestroyShip()
        {
            Destroy(gameObject);
        }

        public Transform GetTransform()
        {
            return gameObject.transform;
        }

        public LayerMask GetLayerMask()
        {
            return (LayerMask)(1 << gameObject.layer);
        }
    }
}