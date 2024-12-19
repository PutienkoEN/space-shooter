namespace Game.Modules.SaveLoad
{
    public interface IGameContextRepository
    {
        public void Save();
        public void Load();
    }
}