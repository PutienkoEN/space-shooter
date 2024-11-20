// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveQueueInstaller.cs
// ------------------------------------------------------------------------------

using Game.Modules.Enemy.Scripts;
using Game.Modules.EnemyGroup.Scripts;
using Game.Modules.Wave.Config;
using Game.Modules.Wave.Waves;
using UnityEngine;
using Zenject;

namespace Game.Modules.Wave
{
    public sealed class WaveQueueInstaller : MonoInstaller
    {
        //TODO For now, that's it. When there's an entry point to the level itself, move it there.
        [SerializeField] private WaveListConfig listWaveConfig;
        [SerializeField] private Transform worldTransform;
        
        public override void InstallBindings()
        {
            Container.BindInstance(listWaveConfig);
            
            Container.BindInterfacesAndSelfTo<EnemyFactory>()
                .AsSingle()
                .WithArguments(worldTransform);

            Container.BindInterfacesAndSelfTo<EnemyGroupManager>()
                .AsSingle();

            
            Container.BindInterfacesAndSelfTo<WavesFactory>().AsSingle().NonLazy();
            
            Container.Bind<WaveEnemyGroup>().AsTransient();
            Container.Bind<WaveDelay>().AsTransient();
            Container.Bind<WaveEvent>().AsTransient();
            
            Container.BindInterfacesAndSelfTo<WaveQueueSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}