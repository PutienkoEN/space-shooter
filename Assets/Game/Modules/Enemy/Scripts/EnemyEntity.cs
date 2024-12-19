using System;
using Game.Modules.BulletModule.Scripts;
using Game.Modules.Common.Interfaces;
using Game.Modules.Components;
using Game.Modules.ShootingModule.Scripts;
using Zenject;

namespace SpaceShooter.Game.Enemy
{
    [Serializable]
    public class EnemyEntity : IDisposable, IEnemyEntity
    {
        public event Action<IEnemyEntity> OnLeftGameArea;
        public event Action<bool> OnStateChanged;
        public event Action<bool> OnInGameStateChanged;

        private readonly BoundsCheckComponent _boundsCheckComponent;
        private readonly CollisionDamageComponent _collisionDamageComponent;
        private readonly WeaponController _weaponController;
        private readonly IEnemyView _enemyView;

        private bool _isActive;
        private bool _isInGame;

        [Inject]
        public EnemyEntity(
            BoundsCheckComponent boundsCheckComponent,
            WeaponController weaponController,
            IEnemyView enemyView)
        {
            _boundsCheckComponent = boundsCheckComponent;
            _weaponController = weaponController;
            _enemyView = enemyView;
        }

        public void Initialize()
        {
            SetIsActive(true);
        }

        public void Dispose()
        {
            _enemyView.Dispose();
        }

        public void Update(float deltaTime)
        {
            if (!_isActive)
            {
                return;
            }

            _boundsCheckComponent.IsInGame(
                _enemyView.GetCollider(),
                SetIsInGame,
                InvokeOnLeftGameArea);

            if (!_isInGame)
            {
                return;
            } 

            _weaponController.Tick(deltaTime);
        }

        public void SetIsActive(bool value)
        {
            if (_isActive == value)
            {
                return;
            }

            _isActive = value;
            OnStateChanged?.Invoke(_isActive);
        }

        private void SetIsInGame(bool value)
        {
            if (_isInGame == value)
            {
                return;
            }

            _isInGame = value;
            OnInGameStateChanged?.Invoke(value);
        }

        private void InvokeOnLeftGameArea()
        {
            OnLeftGameArea?.Invoke(this);
        }

        public class Factory : PlaceholderFactory<EnemyCreateData, EnemyEntity>
        {
        }
    }
}