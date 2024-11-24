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
        public BulletController(BulletSpawner bulletSpawner)
        {
            _bulletSpawner = bulletSpawner;
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
            foreach (var bullet in _bullets)
            {
                bullet.OnUpdate(deltaTime);
            }
        }
        
    }
}