using System.Collections.Generic;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController : IGameListener, IGameTickable
    {
        private float _scrollSpeed;
        private float _offset;

        private readonly List<IBackgroundPresenter> _backgroundPresenters;

        public BackgroundController(List<IBackgroundPresenter> backgroundPresenters)
        {
            _backgroundPresenters = backgroundPresenters;
        }
        public void AddToList(IBackgroundPresenter presenter)
        {
            _backgroundPresenters.Add(presenter);
        }

        private void ScrollBackground(float deltaTime)
        {
            foreach (var presenter in _backgroundPresenters)
            {
                presenter.ScrollBackground(deltaTime);
            }
        }

        public void Tick(float deltaTime)
        {
            ScrollBackground(deltaTime);
        }
    }
}