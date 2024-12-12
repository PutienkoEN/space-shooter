using Zenject;

namespace Game.Modules.BulletModule
{
    public class BulletEntityFactory
    {
        private readonly BulletViewFactory _bulletViewBulletViewFactory;

        public BulletEntityFactory(BulletViewFactory bulletViewBulletViewFactory)
        {
            _bulletViewBulletViewFactory = bulletViewBulletViewFactory;
        }

        public BulletEntity Create(BulletView bulletPrefab, BulletData bulletData)
        {
            var bulletView = _bulletViewBulletViewFactory.Create(bulletPrefab, bulletData);
            var context = bulletView.GetComponent<GameObjectContext>();

            return context.Container.Resolve<BulletEntity>();
        }
    }
}