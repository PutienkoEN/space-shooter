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

        public bool LeftGameArea(Collider collider)
        {
            var onScreen = OnScreen(collider);
            return _wasOnScreen && !onScreen;
        }

        private bool OnScreen(Collider collider)
        {
            var colliderRect = _rectProvider.GetColliderRect(collider);
            return _worldCoordinates.WorldBounds.Overlaps(colliderRect);
        }
    }
}