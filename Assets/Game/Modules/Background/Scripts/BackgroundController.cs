using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController : IGameListener, IGameTickable
    {
        private readonly LazyInject<List<IBackgroundPresenter>> _backgroundPresenters;

        public BackgroundController(LazyInject<List<IBackgroundPresenter>> backgroundPresenters)
        {
            _backgroundPresenters = backgroundPresenters;
        }

        public void Tick(float deltaTime)
        {
            ScrollBackground(deltaTime);
        }
        
        private void ScrollBackground(float deltaTime)
        {
            foreach (var presenter in _backgroundPresenters.Value)
            {
                presenter.ScrollBackground(deltaTime);
            }
        }
    }
}