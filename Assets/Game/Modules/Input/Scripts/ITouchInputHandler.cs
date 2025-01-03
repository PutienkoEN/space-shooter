﻿using System;
using UnityEngine;

namespace SpaceShooter.Game.Input
{
    public interface ITouchInputHandler
    {
        public event Action<Vector3> OnTouchStarted;
        public event Action OnTouchFinished;
        public event Action<Vector3> OnTouchPositionChange;
    }
}