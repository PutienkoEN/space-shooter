using System;
using UnityEngine;

namespace SpaceShooter.Game.Input
{
    public interface ITouchInputMovementHandler
    {
        public event Action<Vector3> OnPositionChange;
    }
}