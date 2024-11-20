// ------------------------------------------------------------------------------
// <author>: Iurii Ponomarev (Ponyu)
// <created>: 2024-11-20
// <file>: EnemyGroupInstaller.cs
// ------------------------------------------------------------------------------

using Game.Modules.Enemy.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Modules.EnemyGroup.Scripts
{
    public sealed class EnemyGroupInstaller : MonoInstaller
    {
        //[SerializeField] private EnemyGroupConfig enemyGroupConfig;
        [SerializeField] private Transform worldTransform;
        
        public override void InstallBindings()
        {
            //Container.BindInstance(enemyGroupConfig);
            Container.BindInterfacesAndSelfTo<EnemyFactory>()
                .AsSingle()
                .WithArguments(worldTransform);

            Container.BindInterfacesAndSelfTo<EnemyGroupManager>()
                .AsSingle();
        }
    }
}