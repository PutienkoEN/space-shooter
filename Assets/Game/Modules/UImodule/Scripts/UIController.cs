using SpaceShooter.Game.LifeCycle.Common;


namespace Game.Modules.UImodule.Scripts
{
    public sealed class UIController : IGameFinishListener
    {
        private readonly IPopup _endGamePopup;

        public UIController(IPopup endGamePopup)
        {
            _endGamePopup = endGamePopup;
        }
        
        public void OnGameFinish()
        {
            _endGamePopup.SetActive(false);
        }
    }
}