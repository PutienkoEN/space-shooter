using Zenject;

namespace Game.Modules.SaveLoad
{
    public class SaveLoadInstaller : Installer<string, SaveLoadInstaller>
    {
        private readonly string _encryptionKey;

        public SaveLoadInstaller(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }

        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadManager>()
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