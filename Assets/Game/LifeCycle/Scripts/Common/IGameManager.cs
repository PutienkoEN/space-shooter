// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: IGameManager.cs
// ------------------------------------------------------------------------------

using System;

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IGameManager : IGameManagerState, IGameManagerListeners
    {
        public event Action OnGamePause;
        public event Action OnGameResume;
    }
}