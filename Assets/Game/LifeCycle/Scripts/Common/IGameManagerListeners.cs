// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-12
// <file>: IGameManagerListeners.cs
// ------------------------------------------------------------------------------

namespace SpaceShooter.Game.LifeCycle.Common
{
    public interface IGameManagerListeners
    {
        public void AddListener(IGameListener gameListener);
        public void RemoveListener(IGameListener gameListener);
    }
}