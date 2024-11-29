using SpaceShooter.Game.CameraUtility;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public sealed class BoundsCheckComponent
    {
        private readonly IWorldCoordinates _worldCoordinates;
        private readonly IRectProvider _rectProvider;
        
        public BoundsCheckComponent(
            IWorldCoordinates worldCoordinates, 
            IRectProvider rectProvider)
        {
            _worldCoordinates = worldCoordinates;
            _rectProvider = rectProvider;
        }

        public bool IsInBounds(Collider collider)
        {
            return _worldCoordinates.WorldBounds.Overlaps(_rectProvider.GetColliderRect(collider));
        }
    }
}