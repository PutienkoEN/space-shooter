using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundPresenter : IBackgroundPresenter
    {
        private float _offset;
        private readonly float _speed;
        private readonly IBackgroundView _backgroundView;

        public BackgroundPresenter(IBackgroundView backgroundView, float speed)
        {
            _backgroundView = backgroundView;
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
            _backgroundView.ScrollBackground(new Vector2(0, CalculateOffset(deltaTime)));
        }
    }
}