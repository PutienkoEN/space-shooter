using System;
using UnityEngine;

namespace SpaceShooter.Input
{
    public interface ITouchInputHandler
    {
        public event Action<Vector2> OnTouchStarted;
        public event Action OnTouchFinished;
        public event Action<Vector2> OnTouchPositionChange;
    }
}