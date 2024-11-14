using System;
using UnityEngine;

namespace SpaceShooter.Input
{
    public interface ITouchInputMovementHandler
    {
        public event Action<Vector2> OnPositionChange;
    }
}