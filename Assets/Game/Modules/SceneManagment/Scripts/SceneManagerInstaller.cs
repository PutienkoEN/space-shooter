using Game.Modules.Level;
using Game.Modules.SaveLoad;
using SpaceShooter.Game.Level;
using SpaceShooter.Game.SceneManagement;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.SceneManagementSceneManagement
{
    public class SceneManagerInstaller : MonoInstaller
    {
        [SerializeField] private LevelConfigList levelsConfiguration;
        [SerializeField] private bool enableAutonomousGameScene;
        [SerializeField] private string encryptionKey;

        public override void InstallBindings()
        {
            Container
                .Bind<GameSceneManager>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesTo<GameContext>()
                .AsSingle()
                .WithArguments(enableAutonomousGameScene)
                .NonLazy();

            Container
                .Bind<DebugSceneManager>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container
                .Bind<LevelConfigListData>()
                .FromInstance(levelsConfiguration.GetData())
                .AsSingle();

            Container
                .Bind<LevelManager>()
                .AsSingle();

            SaveLoadConfiguration();
        }

        private void SaveLoadConfiguration()
        {
            Container
                .BindInterfacesTo<LevelSaveLoader>()
                .AsSingle();
            
            SaveLoadInstaller.Install(Container, encryptionKey);
        }
    }
}