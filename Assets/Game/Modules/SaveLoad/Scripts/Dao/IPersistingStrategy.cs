namespace Game.Modules.SaveLoad
{
    public interface IPersistingStrategy
    {
        public void Save(string data);
        public bool TryLoad(out string data);
    }
}