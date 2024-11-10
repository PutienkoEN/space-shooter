using UnityEngine;
using BackgroundModule;
using Zenject;

namespace SpaceShooter
{
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed;
        
        private BackgroundScroller _backgroundScroller;

        [Inject]
        private void Construct(BackgroundScroller backgroundScroller)
        {
            _backgroundScroller = backgroundScroller;
        }
        private void Update()
        {
            _backgroundScroller.SetScrollSpeed(scrollSpeed);
        }
    }
}