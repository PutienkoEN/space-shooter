using DG.Tweening;
using UnityEngine;

namespace Game.Modules.GameSpeed
{
    public class GameTimeScaleManager : IGameTimeScaleManager
    {
        public void ChangeTimeScale(float targetTimeScale)
        {
            Time.timeScale = targetTimeScale;
        }

        public Tween ChangeTimeScale(float targetTimeScale, float duration)
        {
            return DOTween
                .To(() => Time.timeScale,
                    x => Time.timeScale = x,
                    targetTimeScale,
                    duration)
                .SetUpdate(true);
        }
    }
}