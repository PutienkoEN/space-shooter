using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundPresenter : IBackgroundPresenter
    {
        private float _offset;
        private readonly float _speed;
        private readonly Material _backgroundMaterial;
        private const string MAP_KEY = "_BaseMap";

        public BackgroundPresenter(Material backgroundMaterial, float speed)
        {
            _backgroundMaterial = backgroundMaterial;
            _speed = speed;
        }

        private float UpdateOffset(float value)
        {
            _offset += value;
            return _offset;
        }

        private float CalculateOffset(float deltaTime)
        {
            var offset = (deltaTime * _speed * -1) / 10f;
            return UpdateOffset(offset);
        }

        public void ScrollBackground(float deltaTime)
        {
            // _backgroundView.ScrollBackground(new Vector2(0, CalculateOffset(deltaTime)));
            _backgroundMaterial.SetTextureOffset(MAP_KEY, new Vector2(0f, CalculateOffset(deltaTime)));
        }
    }
}