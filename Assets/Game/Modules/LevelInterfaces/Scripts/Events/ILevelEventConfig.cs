using SpaceShooter.Game.Level.Events;

namespace GSpaceShooter.Game.Level.Events
{
    public interface ILevelEventConfig<out T> where T : ILevelEventData
    {
        public T GetData();
    }
}