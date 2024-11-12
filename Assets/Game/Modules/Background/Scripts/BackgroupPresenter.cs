namespace SpaceShooter.Background
{
    public class BackgroupPresenter : IBackgroundPresenter
    {
        private float _offset;
        private float _speed;
        private IBackgroundView _backgroundView;

        public BackgroupPresenter(IBackgroundView backgroundView, float speed)
        {
            _backgroundView = backgroundView;
            _speed = speed;
        }

        public void UpdateSpeed(float value)
        {
            _speed = value;
        }

        public float UpdateOffset(float value)
        {
            _offset += value;
            return _offset;
        }

        public IBackgroundView GetView()
        {
            return _backgroundView;
        }

        public float GetSpeed()
        {
            return _speed;
        }
    }
}