using SpaceShooter.Game.LifeCycle.Common;
using UnityEngine;
using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class Bullet
    {
        private BulletComponent.Factory _bulletComponentFactory;
        private BulletComponent _bulletComponent;
        
        public Bullet(BulletComponent.Factory bulletComponentFactory)
        {
            _bulletComponentFactory = bulletComponentFactory;
            AddBulletComponent();
        }

        public BulletComponent GetBulletComponent()
        {
            return _bulletComponent;
        }

        private BulletComponent CreateBulletComponent()
        {
            return _bulletComponentFactory.Create();
        }

        private void AddBulletComponent()
        {
            _bulletComponent = CreateBulletComponent();
        }
        
        public class Factory : PlaceholderFactory<Bullet>
        {
        }
    }
}