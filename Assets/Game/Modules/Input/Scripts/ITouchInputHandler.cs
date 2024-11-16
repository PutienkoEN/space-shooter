using System;
using UnityEngine;

namespace SpaceShooter.Game.Input
{
    public interface ITouchInputHandler
    {
        public event Action<Vector2> OnTouchStarted;
        public event Action OnTouchFinished;
        public event Action<Vector2> OnTouchPositionChange;
    }
}