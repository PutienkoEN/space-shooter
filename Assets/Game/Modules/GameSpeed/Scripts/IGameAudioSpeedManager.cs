using DG.Tweening;

namespace Game.Modules.GameSpeed
{
    public interface IGameAudioSpeedManager
    {
        public void ChangePitch(float pitchScale);
        public Tween ChangePitch(float pitchScale, float duration);
    }
}