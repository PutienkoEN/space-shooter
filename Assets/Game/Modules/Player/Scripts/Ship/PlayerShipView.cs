using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipView : MonoBehaviour
    {
        public void DestroyShip()
        {
            Destroy(gameObject);
        }
    }
}