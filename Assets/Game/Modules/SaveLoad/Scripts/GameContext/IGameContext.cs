namespace Game.Modules.SaveLoad
{
    public interface IGameContext
    {
        public void SetData<T>(T value);
        public bool TryGetData<T>(out T value);
    }
}