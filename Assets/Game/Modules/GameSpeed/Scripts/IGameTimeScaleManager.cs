using DG.Tweening;

namespace Game.Modules.GameSpeed
{
    public interface IGameTimeScaleManager
    {
        public void ChangeTimeScale(float targetTimeScale);
        public Tween ChangeTimeScale(float targetTimeScale, float duration);
    }
}