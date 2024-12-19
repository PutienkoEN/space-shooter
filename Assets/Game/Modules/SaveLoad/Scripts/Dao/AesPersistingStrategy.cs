namespace Game.Modules.SaveLoad
{
    public class AesPersistingStrategy : IPersistingStrategy
    {
        private readonly IPersistingStrategy _persistingStrategy;
        private readonly AesEncryptor _aesEncryptor;

        public AesPersistingStrategy(IPersistingStrategy persistingStrategy, AesEncryptor aesEncryptor)
        {
            _persistingStrategy = persistingStrategy;
            _aesEncryptor = aesEncryptor;
        }

        public void Save(string data)
        {
            var encryptedValue = _aesEncryptor.Encrypt(data);
            _persistingStrategy.Save(encryptedValue);
        }

        public bool TryLoad(out string data)
        {
            if (!_persistingStrategy.TryLoad(out var loadedData))
            {
                data = default;
                return false;
            }

            data = _aesEncryptor.Decrypt(loadedData);
            return true;
        }
    }
}