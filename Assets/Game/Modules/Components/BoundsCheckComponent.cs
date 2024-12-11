using System;
using SpaceShooter.Game.CameraUtility;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BoundsCheckComponent
    {
        private readonly IWorldCoordinates _worldCoordinates;
        private readonly IRectProvider _rectProvider;
        private bool _wasOnScreen;

        public BoundsCheckComponent(
            IWorldCoordinates worldCoordinates,
            IRectProvider rectProvider)
        {
            _worldCoordinates = worldCoordinates;
            _rectProvider = rectProvider;
        }

        public bool IsInGame(Collider collider, Action<bool> setIsActive, Action invokeLeftScreen)
        {
            bool onScreen = OnScreen(collider);
            if (onScreen && !_wasOnScreen)
            {
                _wasOnScreen = true;
                setIsActive(true);
                return true;
            }
            
            if (!onScreen && _wasOnScreen)
            {
                _wasOnScreen = false;
                setIsActive(false);
                invokeLeftScreen();
            }
            
            return false;
        }

        public bool OnScreen(Collider collider)
        {
            var colliderRect = _rectProvider.GetColliderRect(collider);
            return _worldCoordinates.WorldBounds.Overlaps(colliderRect);
        }
    }
}