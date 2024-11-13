// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: IGameManagerState.cs
// ------------------------------------------------------------------------------

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IGameManagerState
    {
        GameState State { get; }
        void StartGame();
        void PauseGame();
        void ResumeGame();
        void FinishGame();
    }
}