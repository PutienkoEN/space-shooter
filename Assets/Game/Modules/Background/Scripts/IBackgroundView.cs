using UnityEngine;

namespace SpaceShooter.Background
{
    public interface IBackgroundView
    {
        public void ScrollBackground(Vector2 offset);
    }
}