using UnityEngine;
using Zenject;

namespace SpaceShooter.Input
{
    /*
     * Utility class to store generic helper methods of world data.
     */
    public sealed class WorldUtility
    {
        private readonly Camera _camera;

        private readonly float _worldMinX, _worldMaxX, _worldMinY, _worldMaxY;

        [Inject]
        public WorldUtility(Camera camera)
        {
            _camera = camera;

            _worldMinX = _camera.ViewportToWorldPoint(Vector3.zero).x;
            _worldMaxX = _camera.ViewportToWorldPoint(Vector3.right).x;

            _worldMinY = _camera.ViewportToWorldPoint(Vector3.zero).y;
            _worldMaxY = _camera.ViewportToWorldPoint(Vector3.up).y;
        }

        public Vector3 ClampToScreen(Vector3 position, float objectWidth, float objectHeight)
        {
            var halfOfWidth = objectWidth / 2;
            var clampX = Mathf.Clamp(position.x, _worldMinX + halfOfWidth, _worldMaxX - halfOfWidth);

            var halfOfHeight = objectHeight / 2;
            var clampY = Mathf.Clamp(position.y, _worldMinY + halfOfHeight, _worldMaxY - halfOfHeight);

            return new Vector3(clampX, clampY, position.z);
        }

        public Vector3 ToWorldPosition(Vector2 position)
        {
            return _camera.ScreenToWorldPoint(position);
        }
    }
}