using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.Scores.DI
{
    public class ScoreManagerInstaller : GameModuleInstaller
    {
        [SerializeReference] private ScoreView scoreView;

        public override void Install(DiContainer container)
        {
            container
                .Bind<ScoreManager>()
                .AsSingle();

            container
                .BindInterfacesTo<ScoreViewController>()
                .AsSingle()
                .NonLazy();

            container
                .Bind<IScoreView>()
                .FromInstance(scoreView)
                .AsSingle();
        }
    }
}