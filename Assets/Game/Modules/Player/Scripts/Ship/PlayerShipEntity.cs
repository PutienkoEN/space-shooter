using System;
using Game.Modules.Common.Interfaces;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.Components;
using UnityEngine;
using Zenject;

namespace SpaceShooter.Game.Player.Ship
{
    public sealed class PlayerShipEntity : IInitializable, IDisposable, IEntity
    {
        private readonly IPlayerShipView _playerShipView;
        private readonly PlayerMoveController _playerMoveController;
        private readonly WeaponController _weaponController;

        public readonly HealthComponent HealthComponent;

        private bool _isActive;

        [Inject]
        public PlayerShipEntity(
            IPlayerShipView playerShipView,
            PlayerMoveController playerMoveController,
            WeaponController weaponController,
            HealthComponent healthComponent)
        {
            _playerShipView = playerShipView;
            _playerMoveController = playerMoveController;
            _weaponController = weaponController;
            HealthComponent = healthComponent;
        }

        public void Initialize()
        {
            _playerShipView.OnTakeDamage += TakeDamage;
        }

        public void Dispose()
        {
            _playerShipView.Destroy();
        }

        public void Update(float deltaTime)
        {
            _playerMoveController.Move(deltaTime);
            _weaponController.Tick(deltaTime);
        }

        public void TakeDamage(int damage)
        {
            HealthComponent.TakeDamage(damage);
        }
        
        public Transform GetCurrentPosition()
        {
            return _playerShipView.GetCollider().transform;
        }

        public class Factory : PlaceholderFactory<PlayerShipEntity>
        {
        }
    }
}