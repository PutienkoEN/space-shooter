using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipView : MonoBehaviour
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
            return (LayerMask)gameObject.layer;
        }
    }
}