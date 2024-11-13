using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController
    {
        private float _scrollSpeed;
        private float _offset;

        private readonly List<IBackgroundPresenter> _backgroundPresenters = new();

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
        
        public void OnUpdate(float deltaTime)
        {
            ScrollBackground(deltaTime);
        }
    }
}