namespace SpaceShooter.Background
{
    public interface IBackgroundPresenter
    {
        public IBackgroundView GetView();
        public float UpdateOffset(float value);
        public float GetSpeed();
    }
}