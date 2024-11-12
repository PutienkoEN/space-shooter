using UnityEngine;
using SpaceShooter.Background;
using Zenject;

namespace SpaceShooter
{
    public sealed class SettingsManager : MonoBehaviour
    {
        private BackgroundController _backgroundController;

        [Inject]
        private void Construct(BackgroundController backgroundController)
        {
            _backgroundController = backgroundController;
        }
        private void Update()
        {
            _backgroundController.OnUpdate(Time.deltaTime);
        }
    }
}