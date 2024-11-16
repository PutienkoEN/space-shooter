// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-16
// <file>: WaveQueueInstaller.cs
// ------------------------------------------------------------------------------

using Game.Modules.Wave.Data;
using UnityEngine;
using Zenject;

namespace Game.Modules.Wave
{
    public sealed class WaveQueueInstaller : MonoInstaller
    {
        //TODO For now, that's it. When there's an entry point to the level itself, move it there.
        [SerializeField] private ListWaveConfig listWaveConfig;
        
        public override void InstallBindings()
        {
            Container.BindInstance(listWaveConfig);
            Container.BindInterfacesAndSelfTo<WaveQueueSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}