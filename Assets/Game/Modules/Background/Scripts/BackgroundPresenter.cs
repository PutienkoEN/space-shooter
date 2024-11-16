using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundPresenter : IBackgroundPresenter
    {
        private const string MAP_KEY = "_BaseMap";
        private const float MULTIPLIER = 10f;
        private readonly float _speed;
        private readonly Material _backgroundMaterial;
        private float _offset;

        public BackgroundPresenter(Material backgroundMaterial, float speed)
        {
            _backgroundMaterial = backgroundMaterial;
            _speed = speed;
        }

        private float CalculateOffset(float deltaTime)
        {
            _offset += (deltaTime * _speed * -1) / MULTIPLIER;
            return _offset;
        }

        public void ScrollBackground(float deltaTime)
        {
            _backgroundMaterial.SetTextureOffset(MAP_KEY, new Vector2(0f, CalculateOffset(deltaTime)));
        }
    }
}