using System.Collections.Generic;
using Game.Modules.Background.Scripts;
using SpaceShooter.Game.LifeCycle.Common;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController : IGameListener, IGameTickable
    {
        private readonly IReadOnlyList<IBackgroundPresenter> _backgroundPresenters;
        public BackgroundController(BackgroundsInstantiator backgroundsInstantiator)
        {
            _backgroundPresenters = backgroundsInstantiator.GetPresentersList();
        }

        public void Tick(float deltaTime)
        {
            ScrollBackground(deltaTime);
        }
        
        private void ScrollBackground(float deltaTime)
        {
            foreach (var presenter in _backgroundPresenters)
            {
                presenter.ScrollBackground(deltaTime);
            }
        }
    }
}