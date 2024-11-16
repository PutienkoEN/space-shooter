using DG.Tweening;

namespace Game.Modules.GameSpeed
{
    public interface IGameTimeScaleManager
    {
        public Tween ChangeTimeScale(float targetTimeScale, float duration);
    }
}