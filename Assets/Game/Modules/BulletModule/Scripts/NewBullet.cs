using Zenject;

namespace Game.Modules.BulletModule.Scripts
{
    public class NewBullet
    {
        private BulletView _bulletView;

        public NewBullet(BulletView bulletView)
        {
            _bulletView = bulletView;
        }
        
        
        public class Factory : PlaceholderFactory<NewBullet>
        {
        }

        public BulletView GetView()
        {
            return _bulletView;
        }
    }
}