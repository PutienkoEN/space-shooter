using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Background
{
    public sealed class BackgroundController
    {
        private float _scrollSpeed;
        private float _offset;

        private readonly List<IBackgroundPresenter> _backgroundPresenters = new();

        // public BackgroundController(IBackgroundView backgroundView)
        // {
        //     _backgroundView = backgroundView;
        // }

        public void AddToList(IBackgroundPresenter presenter)
        {
            _backgroundPresenters.Add(presenter);
        }

        private void CalculateAndScroll(float deltaTime)
        {
            foreach (var presenter in _backgroundPresenters)
            {
                float speed = presenter.GetSpeed();
                float offset = presenter.UpdateOffset((deltaTime * speed *-1) / 10f);
                presenter.GetView().ScrollBackground(new Vector2(0, offset));
            }
            
        }
        
        public void OnUpdate(float deltaTime)
        {
            CalculateAndScroll(deltaTime);
            // _backgroundPresenters.ScrollBackground(new Vector2(0, _offset));
        }
    }
}