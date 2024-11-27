using SpaceShooter.Game.CameraUtility;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class BoundsCheckComponent
    {
        private readonly IWorldCoordinates _worldCoordinates;
        
        public BoundsCheckComponent(
            IWorldCoordinates worldCoordinates)
        {
            _worldCoordinates = worldCoordinates;
        }

        public bool IsInBounds(Rect objBounds)
        {
            return _worldCoordinates.WorldBounds.Overlaps(objBounds);
        }
    }
}