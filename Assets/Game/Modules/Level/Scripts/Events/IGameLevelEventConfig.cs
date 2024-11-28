namespace Game.Modules.Enemy.Scripts
{
    public interface IGameLevelEventConfig<out T> where T : IGameLevelEventData
    {
        public T GetData();
    }
}