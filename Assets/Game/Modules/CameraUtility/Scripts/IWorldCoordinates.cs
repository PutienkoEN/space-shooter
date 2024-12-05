using UnityEngine;

namespace SpaceShooter.Game.CameraUtility
{
    public interface IWorldCoordinates
    {
        public Rect WorldBounds { get; }
    }
}