using SpaceShooter.Game.CameraUtility;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class OutOfBoundsController
    {
        private readonly WorldCoordinates _worldCoordinates;

        public OutOfBoundsController(WorldCoordinates worldCoordinates)
        {
            _worldCoordinates = worldCoordinates;
        }

        public bool IsInBounds(Rect bounds)
        {
            return _worldCoordinates.WorldBounds.Overlaps(bounds);
        }
    }
}