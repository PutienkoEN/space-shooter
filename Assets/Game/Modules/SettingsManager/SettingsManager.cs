using UnityEngine;
using SpaceShooter.Background;
using Zenject;

namespace SpaceShooter
{
    public sealed class SettingsManager : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed;
        
        private BackgroundController _backgroundController;

        [Inject]
        private void Construct(BackgroundController backgroundController)
        {
            _backgroundController = backgroundController;
        }
        private void Update()
        {
            _backgroundController.SetScrollSpeed(scrollSpeed);
            _backgroundController.OnUpdate(Time.deltaTime);
        }
    }
}