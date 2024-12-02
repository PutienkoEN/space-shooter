using System;
using UnityEngine;

namespace SpaceShooter.Game.Player.Ship
{
    public class PlayerShipView : MonoBehaviour, IPlayerShipView
    {
        public event Action<int> OnTakeDamage;


        public void TakeDamage(int damage)
        {
            OnTakeDamage?.Invoke(damage);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}