using Game.Modules.ShootingModule.Scripts;
using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;

namespace Game.Modules.BulletModule.Scripts
{
    public class BulletController : IGameListener, IGameTickable
    {

        public BulletController()
        {
            Debug.Log("BulletController initialized");
        }

        public void Tick(float deltaTime)
        {
            
        }
        
    }
}