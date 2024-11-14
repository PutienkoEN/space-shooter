// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: IGameListener.cs
// ------------------------------------------------------------------------------

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IGameListener { }

    public interface IGameStartListener : IGameListener
    {
        void OnGameStart();
    }
    
    public interface IGamePauseListener : IGameListener
    {
        void OnGamePause();
    }
    
    public interface IGameResumeListener : IGameListener
    {
        void OnGameResume();
    }
    
    public interface IGameFinishListener : IGameListener
    {
        void OnGameFinish();
    }
}