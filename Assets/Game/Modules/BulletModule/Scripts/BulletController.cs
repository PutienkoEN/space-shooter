using System.Collections.Generic;
using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletController : IGameListener, IGameTickable
    {
        private List<BulletEntity> _bullets = new();
        private BulletSpawner _bulletSpawner;
        private OutOfBoundsController _outOfBoundsController;
        public BulletController(BulletSpawner bulletSpawner, OutOfBoundsController outOfBoundsController)
        {
            _bulletSpawner = bulletSpawner;
            _outOfBoundsController = outOfBoundsController;
            _bulletSpawner.OnNewBullet += HandleNewBullet;
            Debug.Log("BulletController initialized");
        }

        private void HandleNewBullet(BulletEntity obj)
        {
            _bullets.Add(obj);
        }

        public void Tick(float deltaTime)
        {
            // Debug.Log("BulletController ticking");
            foreach (BulletEntity bullet in _bullets)
            {
                bullet.OnUpdate(deltaTime);
                Debug.Log("bullet is in bounds : " + 
                          _outOfBoundsController.IsInBounds(bullet.GetView().transform.position));
            }
        }
        
    }
}