using Zenject;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadManagerInstaller : Installer<string, SaveLoadManagerInstaller>
    {
        private readonly string _encryptionKey;

        public SaveLoadManagerInstaller(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }

        public override void InstallBindings()
        {
            Container
                .Bind<SaveLoadManager>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<GameContextRepository>()
                .AsSingle();

            Container
                .BindInterfacesTo<PlayerPrefsPersistingStrategy>()
                .AsSingle()
                .WhenInjectedInto<AesPersistingStrategy>();

            Container
                .Bind<AesEncryptor>()
                .AsSingle()
                .WithArguments(_encryptionKey);

            Container
                .BindInterfacesTo<AesPersistingStrategy>()
                .AsSingle();
        }
    }
}