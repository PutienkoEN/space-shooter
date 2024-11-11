using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController
    {
        private float _scrollSpeed;
        private float _offset;
        
        private readonly IBackgroundView _backgroundView;

        public BackgroundController(IBackgroundView backgroundView)
        {
            _backgroundView = backgroundView;
        }

        private void CalculateScrollSpeed(float deltaTime)
        {
            _offset += (deltaTime * _scrollSpeed *-1) / 10f;
        }

        public void SetScrollSpeed(float value)
        {
            _scrollSpeed = value;
        }
        
        public void OnUpdate(float deltaTime)
        {
            CalculateScrollSpeed(deltaTime);
            _backgroundView.ScrollBackground(new Vector2(0, _offset));
        }
    }
}