using DG.Tweening;

namespace Game.Modules.GameSpeed
{
    public interface IGameAudioSpeedManager
    {
        public Tween ChangePitch(float pitchScale, float duration);
    }
}