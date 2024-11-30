namespace Game.Modules.GameSpeed
{
    public interface IGameSpeedManager
    {
        public void StopTime();
        public void ResumeTime();
        public void StartSlowdown();
        public void StopSlowdown();
    }
}