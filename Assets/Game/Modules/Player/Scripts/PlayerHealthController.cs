using System;
using SpaceShooter.Game.Components;
using Zenject;

namespace SpaceShooter.Game.Player
{
    public class PlayerHealthController : IInitializable, IDisposable
    {
        private readonly HealthComponent _healthComponent;
        private readonly PlayerManager _playerManager;

        [Inject]
        public PlayerHealthController(HealthComponent healthComponent, PlayerManager playerManager)
        {
            _healthComponent = healthComponent;
            _playerManager = playerManager;
        }

        public void Initialize()
        {
            _healthComponent.OnDeath += DestroyShip;
        }

        public void Dispose()
        {
            _healthComponent.OnDeath -= DestroyShip;
        }

        private void DestroyShip()
        {
            _playerManager.DestroyPlayer();
        }
    }
}