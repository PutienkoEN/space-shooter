using System;

namespace Game.Modules.GameSpeed
{
    public interface IGameSpeedManager
    {
        public event Action OnSlowDown;
        public event Action OnNormalSpeed;
        public void SetSlowdown();
        public void StopTime();
        public void ResumeTime();
        public void StartSlowdown();
        public void StopSlowdown();
    }
}