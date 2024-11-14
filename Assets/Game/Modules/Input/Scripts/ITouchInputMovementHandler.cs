using System;
using UnityEngine;

namespace SpaceShooter.Game.Input
{
    public interface ITouchInputMovementHandler
    {
        public event Action<Vector2> OnPositionChange;
    }
}