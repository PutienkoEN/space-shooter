using DG.Tweening;

namespace SpaceShooter.Game.LifeCycle.Core
{
    /// <summary>
    /// Used to configure DOTween globally.
    /// It's suggested to initialize DOTWeen in advance, so we do in this class.
    /// For more info <see href="https://dotween.demigiant.com/documentation.php#init"/>
    /// </summary>
    public class DOTweenConfiguration
    {
        public DOTweenConfiguration()
        {
            DOTween.Init();
        }
    }
}